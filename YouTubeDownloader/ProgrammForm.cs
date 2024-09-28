using System;
using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;
using System.Text.RegularExpressions;
using YouTubeDownloader.lib;
using YouTubeDownloader.model;
using YouTubeDownloader.ytdlpUtil;

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
                var defaultDirFilePath = Path.Combine(Program.programFolderPath, Program.defaultDirectoryPathFileName);
                if (File.Exists(defaultDirFilePath))
                {
                    tbFolder.Text = File.ReadAllText(defaultDirFilePath);
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
                File.WriteAllText(Path.Combine(Program.programFolderPath, Program.defaultDirectoryPathFileName), tbFolder.Text);
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
            if (Globals.lastUrl == tbURL.Text)
            {
                return;
            }

            var isUrl = UrlValidator.IsUrl(tbURL.Text);
            btnDownload.Enabled = isUrl;
            Globals.lastUrl = tbURL.Text;
            cbQuality.Enabled = false;
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

            cbQuality.Enabled = true;
            
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
