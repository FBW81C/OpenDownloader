namespace OpenDownloader
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            btn_save = new Button();
            btn_cancel = new Button();
            gb_notifications = new GroupBox();
            lbl_notificationDuration = new Label();
            sb_notificationDuration = new TrackBar();
            cb_showNotifications = new CheckBox();
            gb_logs = new GroupBox();
            lbl_logPath = new Label();
            btn_browseLogFolder = new Button();
            tb_logSaveDirectory = new TextBox();
            cb_autoSaveLogs = new CheckBox();
            folderBrowserDialog1 = new FolderBrowserDialog();
            gb_afterDownload = new GroupBox();
            rb_nothing = new RadioButton();
            rb_alwaysOpen = new RadioButton();
            rb_navigateWhenClicked = new RadioButton();
            rb_alwaysNavigate = new RadioButton();
            gp_downloadItem = new GroupBox();
            lbl_advancedInfoFormat = new Label();
            cb_advancedInfo = new CheckBox();
            gb_messgeboxes = new GroupBox();
            cb_showErrorMessageBoxes = new CheckBox();
            label1 = new Label();
            gb_notifications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sb_notificationDuration).BeginInit();
            gb_logs.SuspendLayout();
            gb_afterDownload.SuspendLayout();
            gp_downloadItem.SuspendLayout();
            gb_messgeboxes.SuspendLayout();
            SuspendLayout();
            // 
            // btn_save
            // 
            btn_save.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_save.Location = new Point(586, 498);
            btn_save.Margin = new Padding(1);
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(77, 23);
            btn_save.TabIndex = 0;
            btn_save.Text = "Save";
            btn_save.UseVisualStyleBackColor = true;
            btn_save.Click += btn_save_Click;
            // 
            // btn_cancel
            // 
            btn_cancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_cancel.Location = new Point(507, 498);
            btn_cancel.Margin = new Padding(1);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.Size = new Size(77, 23);
            btn_cancel.TabIndex = 1;
            btn_cancel.Text = "Cancel";
            btn_cancel.UseVisualStyleBackColor = true;
            // 
            // gb_notifications
            // 
            gb_notifications.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gb_notifications.Controls.Add(lbl_notificationDuration);
            gb_notifications.Controls.Add(sb_notificationDuration);
            gb_notifications.Controls.Add(cb_showNotifications);
            gb_notifications.Location = new Point(10, 10);
            gb_notifications.Margin = new Padding(1);
            gb_notifications.Name = "gb_notifications";
            gb_notifications.Padding = new Padding(1);
            gb_notifications.Size = new Size(330, 120);
            gb_notifications.TabIndex = 2;
            gb_notifications.TabStop = false;
            gb_notifications.Text = "Notifications";
            // 
            // lbl_notificationDuration
            // 
            lbl_notificationDuration.AutoSize = true;
            lbl_notificationDuration.Location = new Point(8, 56);
            lbl_notificationDuration.Margin = new Padding(1, 0, 1, 0);
            lbl_notificationDuration.Name = "lbl_notificationDuration";
            lbl_notificationDuration.Size = new Size(147, 15);
            lbl_notificationDuration.TabIndex = 2;
            lbl_notificationDuration.Text = "Notification Duration (sec)";
            // 
            // sb_notificationDuration
            // 
            sb_notificationDuration.AccessibleName = "";
            sb_notificationDuration.Location = new Point(11, 73);
            sb_notificationDuration.Margin = new Padding(1);
            sb_notificationDuration.Maximum = 20;
            sb_notificationDuration.Minimum = 1;
            sb_notificationDuration.Name = "sb_notificationDuration";
            sb_notificationDuration.Size = new Size(225, 45);
            sb_notificationDuration.TabIndex = 1;
            sb_notificationDuration.Value = 1;
            sb_notificationDuration.ValueChanged += tb_notificationDuration_ValueChanged;
            // 
            // cb_showNotifications
            // 
            cb_showNotifications.AutoSize = true;
            cb_showNotifications.Location = new Point(11, 27);
            cb_showNotifications.Margin = new Padding(1);
            cb_showNotifications.Name = "cb_showNotifications";
            cb_showNotifications.Size = new Size(124, 19);
            cb_showNotifications.TabIndex = 0;
            cb_showNotifications.Text = "Show notifications";
            cb_showNotifications.UseVisualStyleBackColor = true;
            cb_showNotifications.CheckedChanged += cb_showNotifications_CheckedChanged;
            // 
            // gb_logs
            // 
            gb_logs.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gb_logs.Controls.Add(lbl_logPath);
            gb_logs.Controls.Add(btn_browseLogFolder);
            gb_logs.Controls.Add(tb_logSaveDirectory);
            gb_logs.Controls.Add(cb_autoSaveLogs);
            gb_logs.Location = new Point(12, 135);
            gb_logs.Name = "gb_logs";
            gb_logs.Size = new Size(649, 110);
            gb_logs.TabIndex = 3;
            gb_logs.TabStop = false;
            gb_logs.Text = "Logs";
            // 
            // lbl_logPath
            // 
            lbl_logPath.AutoSize = true;
            lbl_logPath.Location = new Point(9, 56);
            lbl_logPath.Name = "lbl_logPath";
            lbl_logPath.Size = new Size(34, 15);
            lbl_logPath.TabIndex = 3;
            lbl_logPath.Text = "Path:";
            // 
            // btn_browseLogFolder
            // 
            btn_browseLogFolder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_browseLogFolder.Location = new Point(227, 74);
            btn_browseLogFolder.Name = "btn_browseLogFolder";
            btn_browseLogFolder.Size = new Size(101, 23);
            btn_browseLogFolder.TabIndex = 2;
            btn_browseLogFolder.Text = "Browse Folder";
            btn_browseLogFolder.UseVisualStyleBackColor = true;
            btn_browseLogFolder.Click += btn_browseLogFolder_Click;
            // 
            // tb_logSaveDirectory
            // 
            tb_logSaveDirectory.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tb_logSaveDirectory.Location = new Point(9, 74);
            tb_logSaveDirectory.Name = "tb_logSaveDirectory";
            tb_logSaveDirectory.Size = new Size(212, 23);
            tb_logSaveDirectory.TabIndex = 1;
            // 
            // cb_autoSaveLogs
            // 
            cb_autoSaveLogs.AutoSize = true;
            cb_autoSaveLogs.Location = new Point(9, 31);
            cb_autoSaveLogs.Name = "cb_autoSaveLogs";
            cb_autoSaveLogs.Size = new Size(107, 19);
            cb_autoSaveLogs.TabIndex = 0;
            cb_autoSaveLogs.Text = "Auto Save Logs";
            cb_autoSaveLogs.UseVisualStyleBackColor = true;
            cb_autoSaveLogs.CheckedChanged += cb_autoSaveLogs_CheckedChanged;
            // 
            // gb_afterDownload
            // 
            gb_afterDownload.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gb_afterDownload.Controls.Add(rb_nothing);
            gb_afterDownload.Controls.Add(rb_alwaysOpen);
            gb_afterDownload.Controls.Add(rb_navigateWhenClicked);
            gb_afterDownload.Controls.Add(rb_alwaysNavigate);
            gb_afterDownload.Location = new Point(12, 251);
            gb_afterDownload.Name = "gb_afterDownload";
            gb_afterDownload.Size = new Size(651, 130);
            gb_afterDownload.TabIndex = 4;
            gb_afterDownload.TabStop = false;
            gb_afterDownload.Text = "After Download";
            // 
            // rb_nothing
            // 
            rb_nothing.AutoSize = true;
            rb_nothing.Location = new Point(9, 97);
            rb_nothing.Name = "rb_nothing";
            rb_nothing.Size = new Size(69, 19);
            rb_nothing.TabIndex = 3;
            rb_nothing.TabStop = true;
            rb_nothing.Text = "Nothing";
            rb_nothing.UseVisualStyleBackColor = true;
            rb_nothing.CheckedChanged += rb_afterDownload_CheckedChanged;
            // 
            // rb_alwaysOpen
            // 
            rb_alwaysOpen.AutoSize = true;
            rb_alwaysOpen.Location = new Point(9, 72);
            rb_alwaysOpen.Name = "rb_alwaysOpen";
            rb_alwaysOpen.Size = new Size(73, 19);
            rb_alwaysOpen.TabIndex = 2;
            rb_alwaysOpen.TabStop = true;
            rb_alwaysOpen.Text = "Open file";
            rb_alwaysOpen.UseVisualStyleBackColor = true;
            rb_alwaysOpen.CheckedChanged += rb_afterDownload_CheckedChanged;
            // 
            // rb_navigateWhenClicked
            // 
            rb_navigateWhenClicked.AutoSize = true;
            rb_navigateWhenClicked.Location = new Point(9, 47);
            rb_navigateWhenClicked.Name = "rb_navigateWhenClicked";
            rb_navigateWhenClicked.Size = new Size(241, 19);
            rb_navigateWhenClicked.TabIndex = 1;
            rb_navigateWhenClicked.TabStop = true;
            rb_navigateWhenClicked.Text = "Navigate to file when notification clicked";
            rb_navigateWhenClicked.UseVisualStyleBackColor = true;
            rb_navigateWhenClicked.CheckedChanged += rb_afterDownload_CheckedChanged;
            // 
            // rb_alwaysNavigate
            // 
            rb_alwaysNavigate.AutoSize = true;
            rb_alwaysNavigate.Location = new Point(9, 22);
            rb_alwaysNavigate.Name = "rb_alwaysNavigate";
            rb_alwaysNavigate.Size = new Size(143, 19);
            rb_alwaysNavigate.TabIndex = 0;
            rb_alwaysNavigate.TabStop = true;
            rb_alwaysNavigate.Text = "Always navigate to file";
            rb_alwaysNavigate.UseVisualStyleBackColor = true;
            rb_alwaysNavigate.CheckedChanged += rb_afterDownload_CheckedChanged;
            // 
            // gp_downloadItem
            // 
            gp_downloadItem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gp_downloadItem.Controls.Add(label1);
            gp_downloadItem.Controls.Add(lbl_advancedInfoFormat);
            gp_downloadItem.Controls.Add(cb_advancedInfo);
            gp_downloadItem.Location = new Point(12, 387);
            gp_downloadItem.Name = "gp_downloadItem";
            gp_downloadItem.Size = new Size(649, 100);
            gp_downloadItem.TabIndex = 5;
            gp_downloadItem.TabStop = false;
            gp_downloadItem.Text = "Download Item";
            // 
            // lbl_advancedInfoFormat
            // 
            lbl_advancedInfoFormat.AutoSize = true;
            lbl_advancedInfoFormat.Location = new Point(175, 23);
            lbl_advancedInfoFormat.Name = "lbl_advancedInfoFormat";
            lbl_advancedInfoFormat.Size = new Size(308, 15);
            lbl_advancedInfoFormat.TabIndex = 1;
            lbl_advancedInfoFormat.Text = "Video:     [Id] - [Resolution][FPS] - [Ext] - [Codec] - [Note]\r\n";
            // 
            // cb_advancedInfo
            // 
            cb_advancedInfo.AutoSize = true;
            cb_advancedInfo.Location = new Point(9, 22);
            cb_advancedInfo.Name = "cb_advancedInfo";
            cb_advancedInfo.Size = new Size(135, 19);
            cb_advancedInfo.TabIndex = 0;
            cb_advancedInfo.Text = "Show Advanced Info";
            cb_advancedInfo.UseVisualStyleBackColor = true;
            cb_advancedInfo.CheckedChanged += cb_advancedInfo_CheckedChanged;
            // 
            // gb_messgeboxes
            // 
            gb_messgeboxes.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            gb_messgeboxes.Controls.Add(cb_showErrorMessageBoxes);
            gb_messgeboxes.Location = new Point(344, 10);
            gb_messgeboxes.Name = "gb_messgeboxes";
            gb_messgeboxes.Size = new Size(317, 118);
            gb_messgeboxes.TabIndex = 6;
            gb_messgeboxes.TabStop = false;
            gb_messgeboxes.Text = "Message Boxes";
            // 
            // cb_showErrorMessageBoxes
            // 
            cb_showErrorMessageBoxes.AutoSize = true;
            cb_showErrorMessageBoxes.Location = new Point(15, 27);
            cb_showErrorMessageBoxes.Name = "cb_showErrorMessageBoxes";
            cb_showErrorMessageBoxes.Size = new Size(166, 19);
            cb_showErrorMessageBoxes.TabIndex = 0;
            cb_showErrorMessageBoxes.Text = "Show Error Message Boxes";
            cb_showErrorMessageBoxes.UseVisualStyleBackColor = true;
            cb_showErrorMessageBoxes.CheckedChanged += cb_showErrorMessageBoxes_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(175, 48);
            label1.Name = "label1";
            label1.Size = new Size(252, 15);
            label1.TabIndex = 2;
            label1.Text = "Audio:    [Id] - [Codec] ([abr], [asr], [ch]) - [ext]";
            // 
            // SettingsForm
            // 
            AcceptButton = btn_save;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btn_cancel;
            ClientSize = new Size(673, 531);
            Controls.Add(gb_messgeboxes);
            Controls.Add(gp_downloadItem);
            Controls.Add(gb_afterDownload);
            Controls.Add(gb_logs);
            Controls.Add(gb_notifications);
            Controls.Add(btn_cancel);
            Controls.Add(btn_save);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(1);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(485, 375);
            Name = "SettingsForm";
            Text = "OpenDownloader Settings";
            gb_notifications.ResumeLayout(false);
            gb_notifications.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)sb_notificationDuration).EndInit();
            gb_logs.ResumeLayout(false);
            gb_logs.PerformLayout();
            gb_afterDownload.ResumeLayout(false);
            gb_afterDownload.PerformLayout();
            gp_downloadItem.ResumeLayout(false);
            gp_downloadItem.PerformLayout();
            gb_messgeboxes.ResumeLayout(false);
            gb_messgeboxes.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btn_save;
        private Button btn_cancel;
        private GroupBox gb_notifications;
        private CheckBox cb_showNotifications;
        private TrackBar sb_notificationDuration;
        private Label lbl_notificationDuration;
        private GroupBox gb_logs;
        private CheckBox cb_autoSaveLogs;
        private TextBox tb_logSaveDirectory;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button btn_browseLogFolder;
        private Label lbl_logPath;
        private GroupBox gb_afterDownload;
        private RadioButton rb_nothing;
        private RadioButton rb_alwaysOpen;
        private RadioButton rb_navigateWhenClicked;
        private RadioButton rb_alwaysNavigate;
        private GroupBox gp_downloadItem;
        private Label lbl_advancedInfoFormat;
        private CheckBox cb_advancedInfo;
        private GroupBox gb_messgeboxes;
        private CheckBox cb_showErrorMessageBoxes;
        private Label label1;
    }
}