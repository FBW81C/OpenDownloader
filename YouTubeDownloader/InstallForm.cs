using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace YouTubeDownloader
{
    public partial class InstallForm : Form
    {
        ProgrammForm programmForm = new();

        public InstallForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private async void btnInstall_Click(object sender, EventArgs e)
        {
            var installationSuccess = true;

            string folderPath = Program.programFolderPath;
            Directory.CreateDirectory(folderPath);

            pbInstall.Value = 0;

            // yt-dlp
            try
            {
                string fileUrl = "https://github.com/yt-dlp/yt-dlp/releases/latest/download/yt-dlp.exe";
                string fileName = "yt-dlp.exe";
                string filePath = Path.Combine(folderPath, fileName);
                await DownloadFileWithProgressAsync(fileUrl, filePath, new Progress<int>(percent =>
                {
                    pbInstall.Value = percent / 3;
                }));
            }
            catch (Exception ex)
            {
                installationSuccess = false;
                MessageBox.Show($"Failed to download file: {ex.Message}");
                return;

            }

            // ffmpeg
            try
            {
                string fileUrl = "https://github.com/BtbN/FFmpeg-Builds/releases/download/latest/ffmpeg-n7.0-latest-win64-lgpl-7.0.zip";
                string fileName = "ffmpeg.zip";
                string filePath = Path.Combine(folderPath, fileName);
                await DownloadFileWithProgressAsync(fileUrl, filePath, new Progress<int>(percent =>
                {
                    pbInstall.Value = (percent / 3) + 33;
                }));
            }
            catch (Exception ex)
            {
                installationSuccess = false;
                MessageBox.Show($"Failed to download file: {ex.Message}");
                return;
            }

            // unzip
            try
            {
                var zipFolder = Path.Combine(folderPath, "ffmpeg.zip");
                var unzipedFolder = Path.Combine(folderPath, "ffmpeg-n7.0-latest-win64-lgpl-7.0");

                pbInstall.Value = 75;
                ZipFile.ExtractToDirectory(zipFolder, folderPath);
                pbInstall.Value = 85;
                File.Move(Path.Combine(Path.Combine(unzipedFolder, "bin"), "ffmpeg.exe"), Path.Combine(folderPath, "ffmpeg.exe"));
                pbInstall.Value = 90;
                File.Delete(zipFolder);
                pbInstall.Value = 95;
                Directory.Delete(unzipedFolder, true);
                pbInstall.Value = 100;
            }
            catch (Exception ex)
            {
                installationSuccess = false;
                MessageBox.Show($"Failed to unzip file: {ex.Message}");
            }

            if (installationSuccess)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private async Task DownloadFileWithProgressAsync(string url, string filePath, IProgress<int> progress)
        {
            using (HttpClient client = new HttpClient())
            {
                // Send Request to download file
                using (HttpResponseMessage response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
                {
                    response.EnsureSuccessStatusCode();

                    // Get file size
                    var totalBytes = response.Content.Headers.ContentLength ?? -1L;
                    var canReportProgress = totalBytes != -1;

                    // Open stream to save file
                    using (var contentStream = await response.Content.ReadAsStreamAsync())
                    using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        var totalRead = 0L;
                        var buffer = new byte[8192];
                        int bytesRead;
                        while ((bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                        {
                            // Write readed bytes in file
                            await fileStream.WriteAsync(buffer, 0, bytesRead);
                            totalRead += bytesRead;

                            if (canReportProgress)
                            {
                                // Calculate progress in %
                                var percentComplete = (int)((totalRead * 100L) / totalBytes);
                                progress.Report(percentComplete);
                            }
                        }
                    }
                }
            }
        }
    }
  }
