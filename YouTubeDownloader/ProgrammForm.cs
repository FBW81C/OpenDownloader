using System;
using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;
using System.Text.RegularExpressions;

namespace YouTubeDownloader
{
    public partial class ProgrammForm : Form
    {
        public ProgrammForm()
        {
            InitializeComponent();
        }

        private async void buttonDownoad(object sender, EventArgs e)
        {
            string fileUrl = tbURL.Text;
            string folder = tbFolder.Text;

            if (string.IsNullOrEmpty(fileUrl))
            {
                MessageBox.Show("Specifed download url is empty!");
                return;
            }
            if (string.IsNullOrEmpty(folder))
            {
                MessageBox.Show("Specifed download folder is empty!");
                return;
            }
            if (!Directory.Exists(folder))
            {
                MessageBox.Show("Specifed download folder doesn't exist!");
                return;
            }

            try
            {
                pbDownload.Value = 0;
                tbConsole.Clear();
                bool isSuccess = await DownloadFileWithProgressAsync(fileUrl, folder, new Progress<int>(percent =>
                {
                    pbDownload.Value = percent;
                }));

                if (isSuccess)
                {
                    MessageBox.Show($"File successfully saved to: {folder}");
                }
                else
                {
                    MessageBox.Show($"Download failed check output for more information!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to download file: {ex.Message}");
            }
        }

        private async Task<bool> DownloadFileWithProgressAsync(string url, string folder, IProgress<int> progress)
        {
            var arguments = $"-P \"{folder.Replace("\\", "/")}\" \"{url}\"";

            var userPofileFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var programFolder = Path.Combine(userPofileFolder, Program.programFolderName);
            var ytdlpPath = Path.Combine(programFolder, "yt-dlp.exe");

            return await RunYtDlpAsync(ytdlpPath, arguments, progress);
        }

        private async Task<bool> RunYtDlpAsync(string ytDlpPath, string arguments, IProgress<int> progress)
        {
            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = ytDlpPath,
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
                        AppendOutput(args.Data);
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
                        AppendOutput(args.Data);
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

        private void AppendOutput(string? data)
        {
            if (data != null)
            {
                if (tbConsole.InvokeRequired)
                {
                    tbConsole.Invoke(new Action(() => tbConsole.AppendText(data + Environment.NewLine)));
                }
                else
                {
                    tbConsole.AppendText(data + Environment.NewLine);
                }
            }
        }

        private void ParseProgress(string output, IProgress<int> progress)
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

        private void Form1_Load(object sender, EventArgs e)
        {
            try 
            {
                var defaultDirFilePath = Path.Combine(Program.programFolderPath, Program.defaultDirectoryPathFileName);
                if (File.Exists(defaultDirFilePath)) 
                {
                    tbFolder.Text = File.ReadAllText(defaultDirFilePath);
                }
            } catch (Exception ex)
            {
                MessageBox.Show($"Failed to load default directory because: {ex.Message}");
            }
        } 

        private void btnBrowseFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Choose a folder to save file to";
                dialog.ShowNewFolderButton = true;
                DialogResult result = dialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
                {
                    tbFolder.Text = dialog.SelectedPath;
                }
            }
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText(Path.Combine(Program.programFolderPath, Program.defaultDirectoryPathFileName), tbFolder.Text);
                MessageBox.Show($"Successfully set path '{tbFolder.Text}' as default");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to set path as default because: {ex.Message}");
            }
        }
    }
}
