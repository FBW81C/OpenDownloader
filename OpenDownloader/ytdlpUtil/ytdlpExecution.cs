using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using OpenDownloader.lib;
using OpenDownloader.model;

namespace OpenDownloader.ytdlpUtil
{
    internal static class ytdlpExecution
    {
        public static async Task<bool> DownloadFileAsync(string arguments, IProgress<int> progress)
        {
            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = Constants.ytdlpPath,
                        Arguments = arguments,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    },
                    EnableRaisingEvents = true
                };

                bool isSuccess = true;

                process.OutputDataReceived += (sender, args) =>
                {
                    if (args.Data != null)
                    {
                        ParseProgress(args.Data, progress);
                        Program.programForm.AppendConsoleOutput(args.Data);
                        if (args.Data.Contains("ETA"))
                        {
                            Program.programForm.SetETA(args.Data);
                        }
                    }
                };
                process.ErrorDataReceived += (sender, args) =>
                {
                    if (args.Data != null)
                    {
                        if (args.Data.ToLower().Contains("error"))
                        {
                            isSuccess = false;
                        }
                        Program.programForm.AppendConsoleOutput(args.Data);
                    }
                };

                process.Start();

                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                await process.WaitForExitAsync();

                if (process.ExitCode != 0)
                {
                    return false;
                }

                return isSuccess;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                return false;
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

        public static async Task<Video> DownloadVideoInfo(string url)
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

            process.Start();

            string json = await process.StandardOutput.ReadToEndAsync();
            await process.WaitForExitAsync();

            return ParseVideo(json);
        }

        private static Video ParseVideo(string json)
        {
            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;

            var video = new Video
            {
                Title = root.GetProperty("title").GetString(),
                WebpageUrl = root.GetProperty("webpage_url").GetString(),
                ThumbnailUrl = root.TryGetProperty("thumbnail", out var thumb)
                    ? thumb.GetString()
                    : null
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
    }
}
