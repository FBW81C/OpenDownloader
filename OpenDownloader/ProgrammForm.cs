using System.Diagnostics;
using System.Text.Json;
using OpenDownloader.lib;
using OpenDownloader.model;
using OpenDownloader.model.Settings;
using OpenDownloader.ytdlpUtil;

namespace OpenDownloader
{
    public partial class ProgrammForm : Form
    {
        // Notification
        private string? _pendingNotificationPath;

        public ProgrammForm()
        {
            InitializeComponent();
            
            // Execute on Form construction
            notifyIcon1.BalloonTipClicked += NotifyIcon1_MouseClick;

            try
            {
                var path = Constants.Settings.DefaultSaveDirectory;
                if (!string.IsNullOrEmpty(path) && Directory.Exists(path))
                {
                    tbFolder.Text = path;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load default directory because: {ex.Message}");
            }
        }

        private async void btnBrowseFolder_Click(object sender, EventArgs e)
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
                Constants.Settings.DefaultSaveDirectory = tbFolder.Text;
                var json = JsonSerializer.Serialize(Constants.Settings);
                File.WriteAllText(Constants.SETTINGS_FILE_PATH, json);
                MessageBox.Show($"Successfully set path '{tbFolder.Text}' as default");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to set path as default because: {ex.Message}");
            }
        }

        private async void btn_Add_Click(object sender, EventArgs e)
        {
            if (!UrlValidator.IsUrl(tbURL.Text))
            {
                var result = MessageBox.Show("URL doesn't seem to be in a URL format", "Invalid URL", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Cancel)
                    return;
            }

            btn_Add.Enabled = false;
            btn_Add.Text = "Loading...";
            tb_output.Clear();

            var path = tbFolder.Text;
            if (!Path.Exists(path))
            {
                MessageBox.Show("Invalid path", "Path doesn't exist", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btn_Add.Enabled = true;
                btn_Add.Text = "Add Video";
                return;
            }

            Video? video = null;
            try
            {
                video = await ytdlpExecution.DownloadVideoInfo(tbURL.Text, new Progress<string>(data =>
                {
                    tb_output.AppendText(data + Environment.NewLine);
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed downloading video info, reason:\n\n{ex.Message}", "Download Video Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbURL.Text = "";
                btn_Add.Enabled = true;
                btn_Add.Text = "Add Video";
                return;
            }

            var item = new DownloadItem(video) { Width = flowLayoutPanel1.ClientSize.Width - 12};

            item.DownloadClicked += async (_, request) =>
            {
                string? finalFilePath = null;
                try
                {
                    finalFilePath = await ytdlpExecution.DownloadFileAsync(
                        request,
                        path,
                        new Progress<string>(data =>
                        {
                            item.UpdateProgress(data);
                        })
                    );
                }
                catch (Exception ex)
                {
                    SendNotification(
                        "Download failed",
                        "Check output panel for more information!",
                        ToolTipIcon.Error
                    );
                    MessageBox.Show($"Download failed, reason:\n\n{ex.Message}", "Download failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                SendNotification(
                    "Download finished",
                    $"{request.Video.Title}\nThe download completed successfully",
                    ToolTipIcon.Info
                );

                // After Download
                if (Constants.Settings.AfterDownload == AfterDownloadOptions.AlwaysNaviagte)
                {
                    Process.Start("explorer.exe", "/select, \"" + finalFilePath + "\"");
                }
                else if (Constants.Settings.AfterDownload == AfterDownloadOptions.OpenFile)
                {
                    Process.Start(finalFilePath);
                }
                else if (Constants.Settings.AfterDownload == AfterDownloadOptions.NaviagteOnNotificationClick)
                {
                    _pendingNotificationPath = finalFilePath;
                }
            };

            item.DeleteClicked += (sender, _) =>
            {
                var control = (DownloadItem)sender!;
                flowLayoutPanel1.Controls.Remove(control);
                control.Dispose();
            };

            flowLayoutPanel1.Controls.Add(item);

            tbURL.Text = "";
            btn_Add.Enabled = true;
            btn_Add.Text = "Add Video";
        }

        private void NotifyIcon1_MouseClick(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_pendingNotificationPath)) return;
            
            if (!File.Exists(_pendingNotificationPath))
            {
                _pendingNotificationPath = null;
                return;
            }

            try
            {
                Process.Start("explorer.exe", "/select, \"" + _pendingNotificationPath + "\"");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed navigating to file, reason:\n\n{ex.Message}", "Click on Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            finally
            {
                _pendingNotificationPath = null;
            }
        }

        private void btn_copyToClipboard_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_output.Text))
                Clipboard.SetText(tb_output.Text);
        }

        private void aboutOpenClickerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Constants.TEXTS_PATH, "about.txt");

            if (File.Exists(path))
            {
                string content = File.ReadAllText(path);
                MessageBox.Show(content, $"About {Constants.APPLICATION_NAME}", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("About-File not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gitHubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", Constants.LINK_GITHUB);
        }

        private void SendNotification(string title, string message, ToolTipIcon icon)
        {
            if (Constants.Settings.ShowNotifications)
            {
                notifyIcon1.ShowBalloonTip(
                    Constants.Settings.NotificationDurationSec * 1000,
                    title,
                    message,
                    icon
                );
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var settingsForm = new SettingsForm(Constants.Settings);
            settingsForm.ShowDialog();
        }
    }
}
