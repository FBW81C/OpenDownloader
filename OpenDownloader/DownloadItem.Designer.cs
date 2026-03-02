namespace OpenDownloader
{
    partial class DownloadItem
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            pb_thumbnail = new PictureBox();
            lbl_title = new Label();
            cb_quality = new ComboBox();
            cb_fps = new ComboBox();
            btn_download = new Button();
            lbl_estimatedSizeValue = new Label();
            pb_progress = new ProgressBar();
            tb_ETA = new TextBox();
            lbl_FPS = new Label();
            cb_mode = new ComboBox();
            btn_openLog = new Button();
            ((System.ComponentModel.ISupportInitialize)pb_thumbnail).BeginInit();
            SuspendLayout();
            // 
            // pb_thumbnail
            // 
            pb_thumbnail.Location = new Point(-1, -1);
            pb_thumbnail.Margin = new Padding(4, 5, 4, 5);
            pb_thumbnail.Name = "pb_thumbnail";
            pb_thumbnail.Size = new Size(194, 140);
            pb_thumbnail.SizeMode = PictureBoxSizeMode.Zoom;
            pb_thumbnail.TabIndex = 0;
            pb_thumbnail.TabStop = false;
            // 
            // lbl_title
            // 
            lbl_title.AutoSize = true;
            lbl_title.Location = new Point(203, 22);
            lbl_title.Margin = new Padding(4, 0, 4, 0);
            lbl_title.Name = "lbl_title";
            lbl_title.Size = new Size(59, 25);
            lbl_title.TabIndex = 1;
            lbl_title.Text = "label1";
            // 
            // cb_quality
            // 
            cb_quality.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_quality.FormattingEnabled = true;
            cb_quality.Location = new Point(203, 57);
            cb_quality.Margin = new Padding(4, 5, 4, 5);
            cb_quality.Name = "cb_quality";
            cb_quality.Size = new Size(171, 33);
            cb_quality.TabIndex = 2;
            cb_quality.SelectedValueChanged += cb_quality_SelectedValueChanged;
            // 
            // cb_fps
            // 
            cb_fps.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_fps.FormattingEnabled = true;
            cb_fps.Location = new Point(430, 57);
            cb_fps.Margin = new Padding(4, 5, 4, 5);
            cb_fps.Name = "cb_fps";
            cb_fps.Size = new Size(171, 33);
            cb_fps.TabIndex = 3;
            // 
            // btn_download
            // 
            btn_download.Location = new Point(800, 52);
            btn_download.Margin = new Padding(4, 5, 4, 5);
            btn_download.Name = "btn_download";
            btn_download.Size = new Size(107, 38);
            btn_download.TabIndex = 4;
            btn_download.Text = "Download";
            btn_download.UseVisualStyleBackColor = true;
            btn_download.Click += btnDownload_Click;
            // 
            // lbl_estimatedSizeValue
            // 
            lbl_estimatedSizeValue.AutoSize = true;
            lbl_estimatedSizeValue.Location = new Point(797, 22);
            lbl_estimatedSizeValue.Margin = new Padding(4, 0, 4, 0);
            lbl_estimatedSizeValue.Name = "lbl_estimatedSizeValue";
            lbl_estimatedSizeValue.Size = new Size(59, 25);
            lbl_estimatedSizeValue.TabIndex = 6;
            lbl_estimatedSizeValue.Text = "label1";
            // 
            // pb_progress
            // 
            pb_progress.Location = new Point(203, 105);
            pb_progress.Margin = new Padding(4, 5, 4, 5);
            pb_progress.Name = "pb_progress";
            pb_progress.Size = new Size(474, 17);
            pb_progress.TabIndex = 7;
            // 
            // tb_ETA
            // 
            tb_ETA.Location = new Point(685, 97);
            tb_ETA.Margin = new Padding(4, 5, 4, 5);
            tb_ETA.Name = "tb_ETA";
            tb_ETA.ReadOnly = true;
            tb_ETA.Size = new Size(107, 31);
            tb_ETA.TabIndex = 8;
            tb_ETA.Text = "ETA: N/A";
            // 
            // lbl_FPS
            // 
            lbl_FPS.AutoSize = true;
            lbl_FPS.Location = new Point(384, 62);
            lbl_FPS.Margin = new Padding(4, 0, 4, 0);
            lbl_FPS.Name = "lbl_FPS";
            lbl_FPS.Size = new Size(41, 25);
            lbl_FPS.TabIndex = 9;
            lbl_FPS.Text = "FPS";
            // 
            // cb_mode
            // 
            cb_mode.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_mode.FormattingEnabled = true;
            cb_mode.Location = new Point(609, 57);
            cb_mode.Name = "cb_mode";
            cb_mode.Size = new Size(183, 33);
            cb_mode.TabIndex = 10;
            // 
            // btn_openLog
            // 
            btn_openLog.Location = new Point(847, 95);
            btn_openLog.Name = "btn_openLog";
            btn_openLog.Size = new Size(60, 34);
            btn_openLog.TabIndex = 11;
            btn_openLog.Text = "Log";
            btn_openLog.UseVisualStyleBackColor = true;
            btn_openLog.Click += btn_openLog_Click;
            // 
            // DownloadItem
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Menu;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(btn_openLog);
            Controls.Add(cb_mode);
            Controls.Add(lbl_FPS);
            Controls.Add(tb_ETA);
            Controls.Add(pb_progress);
            Controls.Add(lbl_estimatedSizeValue);
            Controls.Add(btn_download);
            Controls.Add(cb_fps);
            Controls.Add(cb_quality);
            Controls.Add(lbl_title);
            Controls.Add(pb_thumbnail);
            Margin = new Padding(4, 5, 4, 5);
            Name = "DownloadItem";
            Size = new Size(919, 140);
            ((System.ComponentModel.ISupportInitialize)pb_thumbnail).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pb_thumbnail;
        private Label lbl_title;
        private ComboBox cb_quality;
        private ComboBox cb_fps;
        private Button btn_download;
        private Label lbl_estimatedSizeValue;
        private ProgressBar pb_progress;
        private TextBox tb_ETA;
        private Label lbl_FPS;
        private ComboBox cb_mode;
        private Button btn_openLog;
    }
}
