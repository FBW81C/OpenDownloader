using System.Diagnostics;
using System.Text;
using System.Text.Json;
using OpenDownloader.model;

namespace OpenDownloader.ytdlpUtil
{
    internal static class ytdlpExecution
    {
        public static async Task DownloadFileAsync(
            DownloadRequest request, 
            string path,
            IProgress<string> output)
        {

            var option = request.Option;
            var video = request.Video;
            var mode = request.Mode;

            var args = $"-P \"{path.Replace("\\", "/")}\" \"{video.WebpageUrl}\" ";
            
            if (request.Mode == DownloadMode.VideoWithAudio)
            {
                args +=
                    $"-f \"bestvideo[vcodec^=avc1][height={option.Height}][width={option.Width}][fps={option.Fps}]" +
                    $"+bestaudio[acodec^=mp4a]/best\"";
            } 
            else if (request.Mode == DownloadMode.VideoOnly)
            {
                args +=
                    $"-f \"bestvideo[vcodec^=avc1][height={option.Height}][width={option.Width}][fps={option.Fps}]\"";
            } 
            else
            {
                args +=
                    $"-f \"bestaudio[acodec^=mp4a]/bestaudio\"";
            }

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

            process.OutputDataReceived += (sender, args) =>
            {
                if (args.Data != null)
                {
                    output.Report(args.Data);
                }
            };
            process.ErrorDataReceived += (sender, args) =>
            {
                if (!string.IsNullOrEmpty(args.Data))
                {
                    errorBuilder.AppendLine(args.Data);
                    output.Report(args.Data);
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

            var video = ParseVideo(json);
            await LoadThumbnailAsync(video, output);

            return video;
        }

        private static Video ParseVideo(string json)
        {
            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;

            var video = new Video
            {
                Title = root.GetProperty("title").GetString(),
                WebpageUrl = root.GetProperty("webpage_url").GetString(),
                ThumbnailUrl = SelectCompatibleThumbnailUrl(root)
            };

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
                    Width = f.GetProperty("width").GetInt32(),
                    Height = h.GetInt32(),
                    Fps = fps.GetInt32(),
                    FormatId = f.GetProperty("format_id").GetString(),
                    EstimatedSize =
                        f.TryGetProperty("filesize", out var fs) && fs.ValueKind != JsonValueKind.Null
                            ? fs.GetInt64()
                            : f.TryGetProperty("filesize_approx", out var fsa)
                                ? fsa.GetInt64()
                                : null
                };

                video.Options.Add(option);
            }

            // Eliminate duplicates (same resolution + fps)
            video.Options = video.Options
                .GroupBy(o => new { o.Width, o.Height, o.Fps })
                .Select(g => g.First())
                .OrderByDescending(o => o.Height)
                .ThenByDescending(o => o.Fps)
                .ToList();

            return video;
        }

        private static string SelectCompatibleThumbnailUrl(JsonElement root)
        {
            if (!root.TryGetProperty("thumbnails", out var thumbs))
                return null;

            var compatible = thumbs.EnumerateArray()
                .Select(t => t.GetProperty("url").GetString())
                .Where(url =>
                    url.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                    url.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                    url.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                .FirstOrDefault();

            return compatible;
        }

        private static async Task LoadThumbnailAsync(Video video, IProgress<string> output)
        {
            if (string.IsNullOrWhiteSpace(video.ThumbnailUrl))
            {
                output.Report($"[GUI] No thumbnail found!");
                video.Thumbnail = Image.FromFile(Path.Combine(Constants.ASSETS_PATH, "Logo", "Logo.png"));
                return;
            }

            using var http = new HttpClient();
            output.Report($"[GUI] Fetching thumbnail: {video.ThumbnailUrl}");
            var bytes = await http.GetByteArrayAsync(video.ThumbnailUrl);

            using var ms = new MemoryStream(bytes);
            using var img = Image.FromStream(ms);

            video.Thumbnail = new Bitmap(img);
        }
    }
}
