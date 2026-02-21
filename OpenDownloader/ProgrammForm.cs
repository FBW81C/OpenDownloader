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
        public List<Video> Videos { get; set; } = [];

        public ProgrammForm()
        {
            InitializeComponent();

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

        private async void btn_Add_Click(object sender, EventArgs e)
        {
            if (!UrlValidator.IsUrl(tbURL.Text))
            {
                return;
            }

            try
            {
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

                var video = await ytdlpExecution.DownloadVideoInfo(tbURL.Text, new Progress<string>(data =>
                {
                    tb_output.AppendText(data + Environment.NewLine);
                }));
                Videos.Add(video);

                var item = new DownloadItem(video)
                {
                    Width = flowLayoutPanel1.ClientSize.Width - 6,
                };

                item.DownloadClicked += async (_, option) =>
                {
                    item.ProgressBar.Value = 0;
                    await ytdlpExecution.DownloadFileAsync(
                        video, 
                        option, 
                        path, 
                        new Progress<int>(percent => 
                        { 
                            item.ProgressBar.Value = percent;
                        }),
                        new Progress<string>(data =>
                        {
                            item.SetETA(data);
                        }
                        ));
                };

                flowLayoutPanel1.Controls.Add(item);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            tbURL.Text = "";
            btn_Add.Enabled = true;
            btn_Add.Text = "Add Video";
        }
    }
}
