using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using OpenDownloader.model;

namespace OpenDownloader.ytdlpUtil
{
    internal static class ytdlpExecution
    {
        public static async Task DownloadFileAsync(
            Video video, 
            VideoOption option,
            string path,
            IProgress<int> progress,
            IProgress<string> etaProgress)
        {
            var args =
                $"-P {path.Replace("\\", "/")} {video.WebpageUrl} " +
                $"-f \"bestvideo[vcodec^=avc1][height={option.Height}][width={option.Width}][fps={option.Fps}]" +
                $"+bestaudio[acodec^=mp4a]/best\" " +
                video.WebpageUrl;

            try
            {
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

                process.OutputDataReceived += (sender, args) =>
                {
                    if (args.Data != null)
                    {
                        ParseProgress(args.Data, progress);
                        if (args.Data.Contains("ETA"))
                        {
                            etaProgress?.Report(args.Data);
                        }
                    }
                };
                process.ErrorDataReceived += (sender, args) =>
                {
                };

                process.Start();

                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                await process.WaitForExitAsync();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private static void ParseProgress(string output, IProgress<int> progress)
        {
            var match = Regex.Match(output, @"\b(\d{1,3})\.*\d*%");  // Searches for "XXX.X%"
            if (match.Success)
            {
                if (int.TryParse(match.Groups[1].Value, out int percent))
                {
                    progress.Report(percent);
                }
            }
        }

        public static async Task<Video> DownloadVideoInfo(
            string url,
            IProgress<string> output
            )
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = Constants.ytdlpPath,
                    Arguments = $"-J {url}",
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
            await LoadThumbnailAsync(video);

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

        private static async Task LoadThumbnailAsync(Video video)
        {
            if (string.IsNullOrWhiteSpace(video.ThumbnailUrl))
            {
                video.Thumbnail = Image.FromFile(Path.Combine(Constants.ASSETS_PATH, "Logo", "Logo.png"));
                return;
            }

            using var http = new HttpClient();
            var bytes = await http.GetByteArrayAsync(video.ThumbnailUrl);

            using var ms = new MemoryStream(bytes);
            using var img = Image.FromStream(ms);

            video.Thumbnail = new Bitmap(img);
        }
    }
}
