using System.Diagnostics;
using System.Text;
using System.Text.Json;
using OpenDownloader.model;

namespace OpenDownloader.ytdlpUtil
{
    internal static class ytdlpExecution
    {
        public static async Task<string> DownloadFileAsync(
            DownloadRequest request, 
            string path,
            IProgress<string> output)
        {
            var args = $"-P \"{path.Replace("\\", "/")}\" --restrict-filenames --progress --newline --print \"after_move:filepath:%(filepath)s\" \"{request.Video.WebpageUrl}\"";
            args += $" -f \"{BuildFormatArg(request.Option, request.Mode)}\"";

            output.Report($"[GUI] Executing: yt-dlp.exe {args}");

            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = Constants.ytdlpPath,
                    Arguments = args,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                },
                EnableRaisingEvents = true
            };

            var errorBuilder = new StringBuilder();

            string? finalFilePath = null;
            process.OutputDataReceived += (sender, e) =>
            {
                if (e.Data != null)
                {
                    output.Report(e.Data);

                    const string prefix = "filepath:";

                    if (e.Data.StartsWith(prefix))
                    {
                        finalFilePath = e.Data.Substring(prefix.Length);
                        output.Report($"[DEBUG] finalFilePath = '{finalFilePath}'");
                    }
                }
            };
            process.ErrorDataReceived += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    errorBuilder.AppendLine(e.Data);
                    output.Report(e.Data);
                }
            };

            process.Start();

            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            await process.WaitForExitAsync();
            process.WaitForExit();

            if (process.ExitCode != 0)
            {
                var message = $"yt-dlp failed (exit code {process.ExitCode}):\n{errorBuilder}";
                output.Report($"[ERROR] {message}");
                throw new InvalidOperationException(message);
            }

            if (string.IsNullOrEmpty(finalFilePath) || !File.Exists(finalFilePath))
            {
                var message = $"Final file path not captured.";
                output.Report($"[GUI ERROR] {message}");
                throw new InvalidOperationException(message);
            }

            return finalFilePath;
        }

        private static string BuildFormatArg(VideoOption option, DownloadMode mode)
        {
            if (option.Type == VideoOptionType.Best)
            {
                return mode switch
                {
                    DownloadMode.VideoWithAudio => "bestvideo+bestaudio/best",
                    DownloadMode.VideoOnly => "bestvideo/best",
                    DownloadMode.AudioOnly => "bestaudio/best",
                    _ => throw new ArgumentOutOfRangeException()
                };
            }

            if (option.Type == VideoOptionType.Worst)
            {
                return mode switch
                {
                    DownloadMode.VideoWithAudio => "worstvideo+worstaudio/worst",
                    DownloadMode.VideoOnly => "worstvideo/worst",
                    DownloadMode.AudioOnly => "worstaudio/worst",
                    _ => throw new ArgumentOutOfRangeException()
                };
            }

            // Specific format
            if (string.IsNullOrEmpty(option.Id))
                throw new InvalidOperationException("Format ID missing");

            return mode switch
            {
                DownloadMode.VideoWithAudio => $"{option.Id}+bestaudio/best",
                DownloadMode.VideoOnly => option.Id,
                DownloadMode.AudioOnly => "bestaudio/best",
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public static async Task<Video> DownloadVideoInfo(
            string url,
            IProgress<string> output
            )
        {
            var args = $"-J {url}";

            output.Report($"[GUI] Executing: yt-dlp.exe {args}");
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = Constants.ytdlpPath,
                    Arguments = args,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            var jsonBuilder = new StringBuilder();
            var errorBuilder = new StringBuilder();

            process.OutputDataReceived += (s, e) =>
            {
                if (e.Data != null)
                {
                    jsonBuilder.AppendLine(e.Data);
                }
            };
            process.ErrorDataReceived += (s, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    errorBuilder.AppendLine(e.Data);
                    output?.Report(e.Data);
                }
            };

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            await process.WaitForExitAsync();

            if (process.ExitCode != 0)
            {
                throw new InvalidOperationException(
                    $"yt-dlp failed (exit code {process.ExitCode}):\n{errorBuilder}");
            }

            var json = jsonBuilder.ToString();

            var video = ParseVideo(json, output);
            await LoadThumbnailAsync(video, output);

            return video;
        }

        private static Video ParseVideo(string json, IProgress<string> output)
        {
            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;

            if (root.TryGetProperty("entries", out var _) || root.TryGetProperty("playlist_count", out var _))
            {
                throw new ArgumentException("Playlist detected, currently playlists aren't supported!");
            }

            var video = new Video
            {
                Title = root.GetProperty("title").GetString() ?? "Unknown",
                WebpageUrl = root.GetProperty("webpage_url").GetString(),
                ThumbnailUrl = SelectCompatibleThumbnailUrl(root, output)
            };

            // Sanitize Slashes (any filepath code will interpret it as folder)
            video.Title = video.Title.Replace("\\", "");
            video.Title = video.Title.Replace("/", "");

            try
            {
                var formats = root.GetProperty("formats");

                foreach (var f in formats.EnumerateArray())
                {
                    // Only Video-Streams
                    if (f.GetProperty("vcodec").GetString() == "none")
                        continue;

                    if (!f.TryGetProperty("height", out var h) || h.ValueKind == JsonValueKind.Null)
                        continue;

                    if (!f.TryGetProperty("fps", out var fps) || fps.ValueKind == JsonValueKind.Null)
                        continue;

                    var option = new VideoOption
                    {
                        Id = f.GetProperty("format_id").GetString(),
                        Width = f.GetProperty("width").GetInt32(),
                        Height = h.GetInt32(),
                        Fps = fps.GetInt32(),
                        Filesize =
                            f.TryGetProperty("filesize", out var fs) && fs.ValueKind != JsonValueKind.Null
                                ? fs.GetInt64()
                                : f.TryGetProperty("filesize_approx", out var fsa)
                                    ? fsa.GetInt64()
                                    : null,
                        Ext = f.GetProperty("ext").GetString(),
                        VCodec = f.GetProperty("vcodec").GetString(),
                        ACodec = f.GetProperty("acodec").GetString(),
                        FormatNote = f.GetProperty("format_note").GetString(),
                    };

                    video.Options.Add(option);
                }

                // Eliminate duplicates (same resolution + fps)
                video.Options = video.Options
                    .OrderByDescending(f => f.Height ?? 0)
                    .ThenByDescending(f => f.Fps ?? 0)
                    .ThenBy(f => f.VCodec == "none")
                    .ToList();
            } 
            catch (Exception ex)
            {
                // An error occured while reading formats, maybe wrong datatype or missing property
                // -> Only set best and worst option
                output.Report($"[GUI] failed parsing JSON: {ex.Message}");
            }

            video.Options.Insert(0, new VideoOption
            {
                Type = VideoOptionType.Best
            });

            video.Options.Add(new VideoOption
            {
                Type = VideoOptionType.Worst
            });

            return video;
        }

        private static string SelectCompatibleThumbnailUrl(JsonElement root, IProgress<string> output)
        {
            if (!root.TryGetProperty("thumbnails", out var thumbs))
            {
                output.Report($"[GUI] No thumbnails found");
                return string.Empty;
            }

            var compatible = thumbs.EnumerateArray()
                .Select(t => t.GetProperty("url").GetString())
                .Where(url =>
                    url.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                    url.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                    url.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                .FirstOrDefault();

            if (compatible == null)
            {
                output.Report($"[GUI] No compatible thumbnails found");
                return string.Empty;
            }

            return compatible;
        }

        private static async Task LoadThumbnailAsync(Video video, IProgress<string> output)
        {
            if (string.IsNullOrWhiteSpace(video.ThumbnailUrl))
            {
                output.Report($"[GUI] No thumbnail found, loading dummy thumbnail");
                video.Thumbnail = Image.FromFile(Path.Combine(Constants.ASSETS_PATH, "Logo", "Logo.png"));
                return;
            }

            try
            {
                using var http = new HttpClient();
                output.Report($"[GUI] Fetching thumbnail: {video.ThumbnailUrl}");
                var bytes = await http.GetByteArrayAsync(video.ThumbnailUrl);

                using var ms = new MemoryStream(bytes);
                using var img = Image.FromStream(ms);

                video.Thumbnail = new Bitmap(img);
            } 
            catch (Exception ex)
            {
                output.Report($"[GUI] Failed fetching thumbnail, loading dummy thumbnail: {ex.Message}");
                video.Thumbnail = Image.FromFile(Path.Combine(Constants.ASSETS_PATH, "Logo", "Logo.png"));
            }
        }
    }
}
