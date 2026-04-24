using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenDownloader.model;

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
            tb_notificationDuration.Value = settings.NotificationDurationSec;
            if (!settings.ShowNotifications)
            {
                tb_notificationDuration.Enabled = false;
            }

        }

        private void cb_showNotifications_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = cb_showNotifications.Checked;

            tb_notificationDuration.Enabled = isChecked;
            LocalSettings.ShowNotifications = isChecked;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            // Sync local settings with external
            Constants.Settings = LocalSettings;

            // TODO: Write to file

            Close();
        }

        private void tb_notificationDuration_ValueChanged(object sender, EventArgs e)
        {
            LocalSettings.NotificationDurationSec = tb_notificationDuration.Value;
        }

        private void cb_autoSaveLogs_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = cb_autoSaveLogs.Checked;

            //tb_notificationDuration.Enabled = isChecked;
            LocalSettings.AutoSaveLog = isChecked;
        }
    }
}
