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
            gb_notifications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sb_notificationDuration).BeginInit();
            gb_logs.SuspendLayout();
            SuspendLayout();
            // 
            // btn_save
            // 
            btn_save.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_save.Location = new Point(415, 378);
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
            btn_cancel.Location = new Point(336, 378);
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
            gb_notifications.Size = new Size(482, 120);
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
            cb_showNotifications.Location = new Point(8, 27);
            cb_showNotifications.Margin = new Padding(1);
            cb_showNotifications.Name = "cb_showNotifications";
            cb_showNotifications.Size = new Size(126, 19);
            cb_showNotifications.TabIndex = 0;
            cb_showNotifications.Text = "Show Notifications";
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
            gb_logs.Size = new Size(478, 110);
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
            btn_browseLogFolder.Location = new Point(324, 73);
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
            tb_logSaveDirectory.Location = new Point(6, 74);
            tb_logSaveDirectory.Name = "tb_logSaveDirectory";
            tb_logSaveDirectory.Size = new Size(312, 23);
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
            // SettingsForm
            // 
            AcceptButton = btn_save;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btn_cancel;
            ClientSize = new Size(502, 411);
            Controls.Add(gb_logs);
            Controls.Add(gb_notifications);
            Controls.Add(btn_cancel);
            Controls.Add(btn_save);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(1);
            Name = "SettingsForm";
            Text = "OpenDownloader Settings";
            gb_notifications.ResumeLayout(false);
            gb_notifications.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)sb_notificationDuration).EndInit();
            gb_logs.ResumeLayout(false);
            gb_logs.PerformLayout();
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
    }
}