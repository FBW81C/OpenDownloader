using OpenDownloader.lib;
using OpenDownloader.model.Settings;
using OpenDownloader.model.Text;
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

            // Message Boxes
            cb_showErrorMessageBoxes.Checked = settings.ShowErrorMessageBoxes;

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

            // After Download remove
            rb_alwaysRemove.Checked = settings.AfterDownloadRemove == AfterDownloadRemoveOptions.Always;
            rb_removeWhenSuccessful.Checked = settings.AfterDownloadRemove == AfterDownloadRemoveOptions.WhenSuccessful;
            rb_removeNever.Checked = settings.AfterDownloadRemove == AfterDownloadRemoveOptions.Never;

            // DownloadItem
            cb_advancedInfo.Checked = settings.ShowAdvancedVideoInfo;

            // History
            cb_enableHistory.Checked = settings.IsHistoryEnabled;
            lbl_historyAmount.Text = Constants.History.Count.ToString() ?? "N/A";

            // Updates
            cb_autoUpdate.Checked = settings.IsAutoUpdateEnabled;
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

        private void cb_advancedInfo_CheckedChanged(object sender, EventArgs e)
        {
            LocalSettings.ShowAdvancedVideoInfo = cb_advancedInfo.Checked;
        }

        private void cb_showErrorMessageBoxes_CheckedChanged(object sender, EventArgs e)
        {
            LocalSettings.ShowErrorMessageBoxes = cb_showErrorMessageBoxes.Checked;
        }

        private void rb_alwaysRemove_CheckedChanged(object sender, EventArgs e)
        {
            var option =
                rb_alwaysRemove.Checked ? AfterDownloadRemoveOptions.Always :
                rb_removeWhenSuccessful.Checked ? AfterDownloadRemoveOptions.WhenSuccessful :
                AfterDownloadRemoveOptions.Never;

            LocalSettings.AfterDownloadRemove = option;
        }

        private void cb_enableHistory_CheckedChanged(object sender, EventArgs e)
        {
            LocalSettings.IsHistoryEnabled = cb_enableHistory.Checked;
        }

        private void btn_resetHistory_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(Constants.HISTORY_PATH))
                {
                    File.Delete(Constants.HISTORY_PATH);
                    Constants.History.Clear();
                    lbl_historyAmount.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed deleting history file, reason:\n\n{ex.Message}\n\nTry deleting the file manually: {Constants.HISTORY_PATH}", "History", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btn_checkForUpdates_Click(object sender, EventArgs e)
        {
            try
            {
                await Updater.CheckForUpdateAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not check for updates, reason:\n{ex.Message}", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cb_autoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            LocalSettings.IsAutoUpdateEnabled = cb_autoUpdate.Checked;
        }
    }
}
