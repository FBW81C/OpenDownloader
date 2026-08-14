using System.Diagnostics;
using System.Text;
using System.Text.Json;
using OpenDownloader.lib;
using OpenDownloader.model;
using OpenDownloader.model.Text;

namespace OpenDownloader.ytdlpUtil
{
    internal static class ytdlpExecution
    {
        public static async Task<string> DownloadFileAsync(
            DownloadRequest request, 
            string path,
            IProgress<string> output)
        {
            var args = $"-P \"{path.Replace("\\", "/")}\" -o \"{request.ManualTitle}.%(ext)s\" --restrict-filenames --progress --newline --print \"after_move:filepath:%(filepath)s\" \"{request.Video.WebpageUrl}\"";

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
                DownloadMode.AudioOnly => option.Id,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public static async Task<Video> DownloadVideoInfo(
            string url,
            IProgress<RichText> output
            )
        {
            var args = $"-J {url}";

            output.Report(new RichText($"Executing: yt-dlp.exe {args}", TextType.Normal, "GUI"));
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

                    if (e.Data.StartsWith("WARNING"))
                    {
                        output?.Report(new RichText(e.Data, TextType.Warning, "YT-DLP"));
                    } 
                    else
                    {
                        output?.Report(new RichText(e.Data, TextType.Error, "YT-DLP"));
                    }
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

        private static Video ParseVideo(string json, IProgress<RichText> output)
        {
            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;

           if (root.TryGetProperty("entries", out var _) || root.TryGetProperty("playlist_count", out var _))
           {
                output.Report(new RichText("Playlist detected, currently playlists aren't supported! This may lead to unexpected behaviour!", TextType.Warning, "GUI"));
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
                    // Skip useless streams
                    if (f.GetProperty("vcodec").GetString() == "none" && f.GetProperty("acodec").GetString() == "none")
                        continue;

                    var option = new VideoOption
                    {
                        // General
                        Id = f.GetProperty("format_id").GetString(),
                        Filesize = JsonParser.GetInt64Flexible(f, "filesize") ?? JsonParser.GetInt64Flexible(f, "filesize_approx"),
                        FormatNote = f.GetProperty("format_note").GetString(),
                        // Video
                        Width = JsonParser.GetInt32Flexible(f, "width"),
                        Height = JsonParser.GetInt32Flexible(f, "height"),
                        Fps = JsonParser.GetInt32Flexible(f, "fps"),
                        VideoExt = f.GetProperty("video_ext").GetString(),
                        VCodec = f.GetProperty("vcodec").GetString(),
                        // Audio
                        AudioExt = f.GetProperty("audio_ext").GetString(),
                        ACodec = f.GetProperty("acodec").GetString(),
                        Abr = JsonParser.GetDoubleFlexible(f, "abr"),
                        Asr = JsonParser.GetInt32Flexible(f, "asr"),
                        AudioChannels = JsonParser.GetInt32Flexible(f, "audio_channels"),
                    };

                    if (f.GetProperty("vcodec").GetString() == "none" && f.GetProperty("acodec").GetString() != "none") // Audio Only Streams
                    {
                        video.AudioOptions.Add(option);
                    }
                    else if (f.GetProperty("vcodec").GetString() != "none" && f.GetProperty("acodec").GetString() == "none") // Video Only Streams
                    {
                        video.Options.Add(option);
                    }
                    else // Video Streams & Video and Audio Streams
                    {
                        video.Options.Add(option);
                    }
                }

                // Eliminate duplicates (same resolution + fps)
                video.Options = video.Options
                    .OrderByDescending(f => f.Height ?? 0)
                    .ThenByDescending(f => f.Fps ?? 0)
                    .ThenBy(f => f.VCodec == "none")
                    .ToList();

                video.AudioOptions = video.AudioOptions
                    .OrderByDescending(f => f.ACodec)
                    .ToList();
            } 
            catch (Exception ex)
            {
                // An error occured while reading formats, maybe wrong datatype or missing property
                // -> Only set best and worst option
                output.Report(new RichText($"failed parsing JSON: {ex.Message}", TextType.Warning, "GUI"));
            }

            video.Options.Insert(0, new VideoOption { Type = VideoOptionType.Best });
            video.Options.Add(new VideoOption { Type = VideoOptionType.Worst });

            video.AudioOptions.Insert(0, new VideoOption { Type = VideoOptionType.Best });
            video.AudioOptions.Add(new VideoOption { Type = VideoOptionType.Worst });

            return video;
        }

        private static string SelectCompatibleThumbnailUrl(JsonElement root, IProgress<RichText> output)
        {
            if (!root.TryGetProperty("thumbnails", out var thumbs))
            {
                output.Report(new RichText("No thumbnails found", TextType.Warning, "GUI"));
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
                output.Report(new RichText($"No compatible thumbnails found", TextType.Warning, "GUI"));
                return string.Empty;
            }

            return compatible;
        }

        private static async Task LoadThumbnailAsync(Video video, IProgress<RichText> output)
        {
            if (string.IsNullOrWhiteSpace(video.ThumbnailUrl))
            {
                output.Report(new RichText($"No thumbnail found, loading default thumbnail", TextType.Warning, "GUI"));
                video.Thumbnail = Image.FromFile(Path.Combine(Constants.ASSETS_PATH, "Logo", "Logo.png"));
                return;
            }

            try
            {
                using var http = new HttpClient();
                output.Report(new RichText($"Fetching thumbnail: {video.ThumbnailUrl}", TextType.Normal, "GUI"));
                var bytes = await http.GetByteArrayAsync(video.ThumbnailUrl);

                using var ms = new MemoryStream(bytes);
                using var img = Image.FromStream(ms);

                video.Thumbnail = new Bitmap(img);
            } 
            catch (Exception ex)
            {
                output.Report(new RichText($"Failed fetching thumbnail, loading default thumbnail: {ex.Message}", TextType.Warning, "GUI"));
                video.Thumbnail = Image.FromFile(Path.Combine(Constants.ASSETS_PATH, "Logo", "Logo.png"));
            }
        }
    }
}
