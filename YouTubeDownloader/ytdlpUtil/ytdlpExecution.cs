using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using YouTubeDownloader.model;

namespace YouTubeDownloader.ytdlpUtil
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
                        FileName = Program.ytdlpPath,
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

        public static async Task<List<string>> DownloadFileInfoAsync(string url)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = Program.ytdlpPath,
                    Arguments = $"-F {url}",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                },
                EnableRaisingEvents = true
            };

            process.Start();

            StreamReader reader = process.StandardOutput;
            string output = reader.ReadToEnd();

            await process.WaitForExitAsync();

            Regex resolutionRegex = new Regex(@"\b\d{3,4}x\d{3,4}");

            HashSet<string> lines = [];
            using (StringReader stringReader = new StringReader(output))
            {
                string line;
                while ((line = stringReader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    Match match = resolutionRegex.Match(line);
                    if (match.Success)
                    {
                        lines.Add(match.Value);
                    }
                }
            }
            return lines.ToList();
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
    }
}
