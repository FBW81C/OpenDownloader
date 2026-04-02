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
            cb_showNotifications = new CheckBox();
            tb_notificationDuration = new TrackBar();
            lbl_notificationDuration = new Label();
            gb_notifications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tb_notificationDuration).BeginInit();
            SuspendLayout();
            // 
            // btn_save
            // 
            btn_save.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_save.Location = new Point(1020, 1054);
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(188, 58);
            btn_save.TabIndex = 0;
            btn_save.Text = "Save";
            btn_save.UseVisualStyleBackColor = true;
            // 
            // btn_cancel
            // 
            btn_cancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_cancel.Location = new Point(826, 1054);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.Size = new Size(188, 58);
            btn_cancel.TabIndex = 1;
            btn_cancel.Text = "Cancel";
            btn_cancel.UseVisualStyleBackColor = true;
            // 
            // gb_notifications
            // 
            gb_notifications.Controls.Add(lbl_notificationDuration);
            gb_notifications.Controls.Add(tb_notificationDuration);
            gb_notifications.Controls.Add(cb_showNotifications);
            gb_notifications.Location = new Point(12, 12);
            gb_notifications.Name = "gb_notifications";
            gb_notifications.Size = new Size(918, 395);
            gb_notifications.TabIndex = 2;
            gb_notifications.TabStop = false;
            gb_notifications.Text = "Notifications";
            // 
            // cb_showNotifications
            // 
            cb_showNotifications.AutoSize = true;
            cb_showNotifications.Location = new Point(27, 68);
            cb_showNotifications.Name = "cb_showNotifications";
            cb_showNotifications.Size = new Size(304, 45);
            cb_showNotifications.TabIndex = 0;
            cb_showNotifications.Text = "Show Notifications";
            cb_showNotifications.UseVisualStyleBackColor = true;
            // 
            // tb_notificationDuration
            // 
            tb_notificationDuration.AccessibleName = "";
            tb_notificationDuration.Location = new Point(27, 190);
            tb_notificationDuration.Maximum = 20;
            tb_notificationDuration.Minimum = 1;
            tb_notificationDuration.Name = "tb_notificationDuration";
            tb_notificationDuration.Size = new Size(546, 114);
            tb_notificationDuration.TabIndex = 1;
            tb_notificationDuration.Value = 1;
            // 
            // lbl_notificationDuration
            // 
            lbl_notificationDuration.AutoSize = true;
            lbl_notificationDuration.Location = new Point(27, 134);
            lbl_notificationDuration.Name = "lbl_notificationDuration";
            lbl_notificationDuration.Size = new Size(364, 41);
            lbl_notificationDuration.TabIndex = 2;
            lbl_notificationDuration.Text = "Notification Duration (sec)";
            // 
            // SettingsForm
            // 
            AcceptButton = btn_save;
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btn_cancel;
            ClientSize = new Size(1220, 1124);
            Controls.Add(gb_notifications);
            Controls.Add(btn_cancel);
            Controls.Add(btn_save);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SettingsForm";
            Text = "OpenDownloader Settings";
            gb_notifications.ResumeLayout(false);
            gb_notifications.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tb_notificationDuration).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btn_save;
        private Button btn_cancel;
        private GroupBox gb_notifications;
        private CheckBox cb_showNotifications;
        private TrackBar tb_notificationDuration;
        private Label lbl_notificationDuration;
    }
}