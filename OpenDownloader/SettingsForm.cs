using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenDownloader.model.Settings;

namespace OpenDownloader
{
    public partial class SettingsForm : Form
    {
        private Settings LocalSettings { get; }
        public SettingsForm(Settings settings)
        {
            InitializeComponent();

            LocalSettings = settings.Clone();

            // Notifications
            cb_showNotifications.Checked = settings.ShowNotifications;
            sb_notificationDuration.Value = settings.NotificationDurationSec;
            if (!settings.ShowNotifications)
            {
                sb_notificationDuration.Enabled = false;
            }

            // Auto Save Log
            cb_autoSaveLogs.Checked = settings.AutoSaveLog;
            tb_logSaveDirectory.Text = settings.LogSaveDirectory;
            if (!settings.AutoSaveLog)
            {
                tb_logSaveDirectory.Enabled = false;
                btn_browseLogFolder.Enabled = false;
            }

            // After Download
            rb_alwaysNavigate.Checked = settings.AfterDownload == AfterDownloadOptions.AlwaysNaviagte;
            rb_navigateWhenClicked.Checked = settings.AfterDownload == AfterDownloadOptions.NaviagteOnNotificationClick;
            rb_alwaysOpen.Checked = settings.AfterDownload == AfterDownloadOptions.OpenFile;
            rb_nothing.Checked = settings.AfterDownload == AfterDownloadOptions.Nothing;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            // Sync local settings with external
            Constants.Settings = LocalSettings;

            try
            {
                var json = JsonSerializer.Serialize(Constants.Settings);
                File.WriteAllText(Constants.SETTINGS_FILE_PATH, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not save settings to: \"{Constants.SETTINGS_FILE_PATH}\"\nSettings will be applied until application restart\n\nReason:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Close();
        }

        private void cb_showNotifications_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = cb_showNotifications.Checked;

            sb_notificationDuration.Enabled = isChecked;

            LocalSettings.ShowNotifications = isChecked;
        }

        private void tb_notificationDuration_ValueChanged(object sender, EventArgs e)
        {
            LocalSettings.NotificationDurationSec = sb_notificationDuration.Value;
        }

        private void cb_autoSaveLogs_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = cb_autoSaveLogs.Checked;

            tb_logSaveDirectory.Enabled = isChecked;
            btn_browseLogFolder.Enabled = isChecked;

            LocalSettings.AutoSaveLog = isChecked;
        }

        private void btn_browseLogFolder_Click(object sender, EventArgs e)
        {
            var result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                var path = folderBrowserDialog1.SelectedPath;

                LocalSettings.LogSaveDirectory = path;
                tb_logSaveDirectory.Text = path;
            }
            else
            {
                return;
            }
        }

        private void rb_afterDownload_CheckedChanged(object sender, EventArgs e)
        {
            var option =
                rb_alwaysNavigate.Checked ? AfterDownloadOptions.AlwaysNaviagte :
                rb_navigateWhenClicked.Checked ? AfterDownloadOptions.NaviagteOnNotificationClick :
                rb_alwaysOpen.Checked ? AfterDownloadOptions.OpenFile :
                AfterDownloadOptions.Nothing;

            LocalSettings.AfterDownload = option;
        }
    }
}
