using System;
using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;
using System.Security.Policy;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using OpenDownloader.lib;
using OpenDownloader.model;
using OpenDownloader.ytdlpUtil;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

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
            //string fileUrl = tbURL.Text;
            //string folder = tbFolder.Text;

            //if (string.IsNullOrEmpty(fileUrl))
            //{
            //    MessageBox.Show("Specifed download url is empty!");
            //    return;
            //}
            //if (string.IsNullOrEmpty(folder))
            //{
            //    MessageBox.Show("Specifed download folder is empty!");
            //    return;
            //}
            //if (!Directory.Exists(folder))
            //{
            //    MessageBox.Show("Specifed download folder doesn't exist!");
            //    return;
            //}

            //try
            //{
            //    pbDownload.Value = 0;
            //    tbConsole.Clear();
            //    var quality = (cbQuality.SelectedItem as Detail)?.Quality;

            //    var fps = cbFPS.SelectedItem;

            //    var arguments = new Dictionary<string, string>
            //    {
            //        { "quality", quality?.ToString()??"Best" },
            //        { "fps", fps?.ToString()??"Best" }
            //    };
            //    bool isSuccess = await Service.DownloadFileWithProgressAsync(fileUrl, folder, arguments, new Progress<int>(percent =>
            //    {
            //        pbDownload.Value = percent;
            //    }));

            //    if (isSuccess)
            //    {
            //        Icon infoIcon = SystemIcons.Information;
            //        NotificationForm notification = new NotificationForm("YouTubeDonwloader", "Successful", $"Successfully donwloaded file to:\n{folder}", infoIcon);
            //        notification.Show();
            //    }
            //    else
            //    {
            //        Icon infoIcon = SystemIcons.Error;
            //        NotificationForm notification = new NotificationForm("YouTubeDonwloader", "Error", $"Failed donwloaded file!\ncheck output window for more information", infoIcon);
            //        notification.Show();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Failed to download file: {ex.Message}");
            //}
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

            if (!isUrl)
            {
                return;
            }

            try
            {
                var video = await ytdlpExecution.DownloadVideoInfo(tbURL.Text);
                var json = JsonSerializer.Serialize(video);
                File.WriteAllText("C:\\DEV\\OpenDownloader\\OpenDownloader\\Assets\\test.txt", json);

                btnDownload.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        private void btnClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbConsole.Text);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Image image = Image.FromFile("C:\\DEV\\OpenDownloader\\OpenDownloader\\Assets\\logo\\Logo.png");

            var video = new Video
            {
                Thumbnail = image,
                Title = $"Test Video Name 123 wow 4k Ultra HD {Guid.NewGuid()}",
                Options = new List<VideoOption>
                {
                    new() {
                        Width = 1920,
                        Height = 1080,
                        EstimatedSize = 10053344430,
                        Fps = 60
                    },
                    new() {
                        Width = 200,
                        Height = 100,
                        EstimatedSize = 10042340,
                        Fps = 30
                    },
                    new() {
                        Width = 1920,
                        Height = 1080,
                        EstimatedSize = 123000,
                        Fps = 24
                    },
                    new() {
                        Width = 123,
                        Height = 313,
                        EstimatedSize = 10040,
                        Fps = 50
                    }
                }
            };

            var item = new DownloadItem(video)
            {
                Width = flowLayoutPanel1.ClientSize.Width - 5,
            };

            item.DownloadClicked += (_, option) =>
            {
                MessageBox.Show($"Click on {item.Title}, Option: {option.Resolution}, {option.Fps}");
            };

            flowLayoutPanel1.Controls.Add(item);
        }
    }
}
