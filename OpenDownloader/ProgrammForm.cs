using System;
using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using OpenDownloader.lib;
using OpenDownloader.model;
using OpenDownloader.ytdlpUtil;

namespace OpenDownloader
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
                var quality = (cbQuality.SelectedItem as Detail)?.Quality;

                var fps = cbFPS.SelectedItem;

                var arguments = new Dictionary<string, string>
                {
                    { "quality", quality?.ToString()??"Best" },
                    { "fps", fps?.ToString()??"Best" }
                };
                bool isSuccess = await Service.DownloadFileWithProgressAsync(fileUrl, folder, arguments, new Progress<int>(percent =>
                {
                    pbDownload.Value = percent;
                }));

                if (isSuccess)
                {
                    Icon infoIcon = SystemIcons.Information;
                    NotificationForm notification = new NotificationForm("YouTubeDonwloader", "Successful",  $"Successfully donwloaded file to:\n{folder}", infoIcon);
                    notification.Show();
                }
                else
                {
                    Icon infoIcon = SystemIcons.Error;
                    NotificationForm notification = new NotificationForm("YouTubeDonwloader", "Error", $"Failed donwloaded file!\ncheck output window for more information", infoIcon);
                    notification.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to download file: {ex.Message}");
            }
        }

        public void AppendConsoleOutput(string? data)
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

        public void SetETA(string data)
        {
            Regex regex = new Regex("ETA *\\d{2}:\\d{2}");
            Match match = regex.Match(data);
            if (match.Success)
            {
                tbETA.Text = match.Value;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                var defaultDirFilePath = Path.Combine(Constants.SETTINGS_PATH, Constants.defaultDirectoryPathFileName);
                if (File.Exists(defaultDirFilePath))
                {
                    tbFolder.Text = File.ReadAllText(defaultDirFilePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load default directory because: {ex.Message}");
            }

            cbFormat.Items.Clear();
            cbFormat.Items.AddRange(["Orginal format", "MP4", "MOV", "WMV", "WEBM", "MP3 - Audio only", "OGG  - Audio only", "WAV  - Audio only", "WMA - Audio only"]);
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
                File.WriteAllText(Path.Combine(Constants.SETTINGS_PATH, Constants.defaultDirectoryPathFileName), tbFolder.Text);
                MessageBox.Show($"Successfully set path '{tbFolder.Text}' as default");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to set path as default because: {ex.Message}");
            }
        }

        private void cb_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Prohibit user from chaning text in Combobox
            e.KeyChar = (char)Keys.None;
        }

        private async void tbURL_Leave(object sender, EventArgs e)
        {
            if (Constants.lastUrl == tbURL.Text)
            {
                return;
            }

            var isUrl = UrlValidator.IsUrl(tbURL.Text);
            btnDownload.Enabled = false;
            Constants.lastUrl = tbURL.Text;
            cbQuality.Enabled = false;
            cbFormat.Enabled = false;
            cbFPS.Enabled = false;

            if (!isUrl)
            {
                cbFPS.Text = "N/A";
                cbQuality.Text = "N/A";
                return;
            }

            cbQuality.DataSource = null;
            cbQuality.Text = "Loading...";
            cbFPS.Text = "Loading...";

            List<Detail> details = [];
            try
            {
                details = await Task.Run(() => Service.GetFileInfoAsync(tbURL.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }

            btnDownload.Enabled = true;
            cbQuality.Enabled = true;
            cbFormat.Enabled = true;
            cbFormat.SelectedIndex = 0;

            cbQuality.DisplayMember = "Quality";
            cbQuality.ValueMember = "Quality";
            cbQuality.DataSource = details;

            if (details.Count > 0)
            {
                cbQuality.SelectedIndex = 0;
            }
            else
            {
                cbQuality.Enabled = false;
                cbQuality.Text = "N/A";
            }
        }

        private void cbQuality_SelectedValueChanged(object sender, EventArgs e)
        {
            var detail = cbQuality.SelectedItem as Detail;
            if (detail == null)
            {
                return;
            }
            tbFilesize.Text = FilesizeParser.GetTextForm(detail.Size);

            cbFPS.Enabled = detail.FPS.Count > 0; // NEU
            cbFPS.DataSource = null; // NEU
            cbFPS.DisplayMember = "FPS";
            cbFPS.DataSource = detail.FPS;

            if (detail.FPS.Count > 0)
            {
                cbFPS.SelectedIndex = 0;
            }
            else
            {
                cbFPS.Text = "N/A";
            }
        }
    }
}
