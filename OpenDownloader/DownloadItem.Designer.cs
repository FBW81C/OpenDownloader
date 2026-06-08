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
            btn_download = new Button();
            lbl_estimatedSizeValue = new Label();
            pb_progress = new ProgressBar();
            tb_ETA = new TextBox();
            cb_mode = new ComboBox();
            btn_openLog = new Button();
            btn_delete = new Button();
            ((System.ComponentModel.ISupportInitialize)pb_thumbnail).BeginInit();
            SuspendLayout();
            // 
            // pb_thumbnail
            // 
            pb_thumbnail.Location = new Point(-1, -1);
            pb_thumbnail.Name = "pb_thumbnail";
            pb_thumbnail.Size = new Size(136, 84);
            pb_thumbnail.SizeMode = PictureBoxSizeMode.Zoom;
            pb_thumbnail.TabIndex = 0;
            pb_thumbnail.TabStop = false;
            // 
            // lbl_title
            // 
            lbl_title.AutoSize = true;
            lbl_title.Location = new Point(142, 13);
            lbl_title.Name = "lbl_title";
            lbl_title.Size = new Size(38, 15);
            lbl_title.TabIndex = 1;
            lbl_title.Text = "label1";
            // 
            // cb_quality
            // 
            cb_quality.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cb_quality.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_quality.FormattingEnabled = true;
            cb_quality.Location = new Point(276, 35);
            cb_quality.Name = "cb_quality";
            cb_quality.Size = new Size(278, 23);
            cb_quality.TabIndex = 2;
            cb_quality.SelectedValueChanged += cb_quality_SelectedValueChanged;
            // 
            // btn_download
            // 
            btn_download.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_download.Location = new Point(560, 34);
            btn_download.Name = "btn_download";
            btn_download.Size = new Size(75, 23);
            btn_download.TabIndex = 4;
            btn_download.Text = "Download";
            btn_download.UseVisualStyleBackColor = true;
            btn_download.Click += btnDownload_Click;
            // 
            // lbl_estimatedSizeValue
            // 
            lbl_estimatedSizeValue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbl_estimatedSizeValue.AutoSize = true;
            lbl_estimatedSizeValue.Location = new Point(558, 13);
            lbl_estimatedSizeValue.Name = "lbl_estimatedSizeValue";
            lbl_estimatedSizeValue.Size = new Size(38, 15);
            lbl_estimatedSizeValue.TabIndex = 6;
            lbl_estimatedSizeValue.Text = "label1";
            // 
            // pb_progress
            // 
            pb_progress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pb_progress.Location = new Point(142, 63);
            pb_progress.Name = "pb_progress";
            pb_progress.Size = new Size(332, 10);
            pb_progress.TabIndex = 7;
            // 
            // tb_ETA
            // 
            tb_ETA.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tb_ETA.Location = new Point(479, 58);
            tb_ETA.Name = "tb_ETA";
            tb_ETA.ReadOnly = true;
            tb_ETA.Size = new Size(76, 23);
            tb_ETA.TabIndex = 8;
            tb_ETA.TabStop = false;
            tb_ETA.Text = "ETA: N/A";
            // 
            // cb_mode
            // 
            cb_mode.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_mode.FormattingEnabled = true;
            cb_mode.Location = new Point(142, 35);
            cb_mode.Margin = new Padding(2);
            cb_mode.Name = "cb_mode";
            cb_mode.Size = new Size(129, 23);
            cb_mode.TabIndex = 10;
            cb_mode.SelectedIndexChanged += cb_mode_SelectedIndexChanged;
            // 
            // btn_openLog
            // 
            btn_openLog.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_openLog.Location = new Point(593, 58);
            btn_openLog.Margin = new Padding(2);
            btn_openLog.Name = "btn_openLog";
            btn_openLog.Size = new Size(42, 23);
            btn_openLog.TabIndex = 11;
            btn_openLog.Text = "Log";
            btn_openLog.UseVisualStyleBackColor = true;
            btn_openLog.Click += btn_openLog_Click;
            // 
            // btn_delete
            // 
            btn_delete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_delete.Image = Properties.Resources.delete;
            btn_delete.Location = new Point(638, 34);
            btn_delete.Name = "btn_delete";
            btn_delete.Size = new Size(23, 23);
            btn_delete.TabIndex = 12;
            btn_delete.UseVisualStyleBackColor = true;
            btn_delete.Click += btn_delete_Click;
            // 
            // DownloadItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Menu;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(btn_delete);
            Controls.Add(btn_openLog);
            Controls.Add(cb_mode);
            Controls.Add(tb_ETA);
            Controls.Add(pb_progress);
            Controls.Add(lbl_estimatedSizeValue);
            Controls.Add(btn_download);
            Controls.Add(cb_quality);
            Controls.Add(lbl_title);
            Controls.Add(pb_thumbnail);
            Margin = new Padding(0, 0, 0, 6);
            Name = "DownloadItem";
            Size = new Size(669, 84);
            ((System.ComponentModel.ISupportInitialize)pb_thumbnail).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pb_thumbnail;
        private Label lbl_title;
        private ComboBox cb_quality;
        private Button btn_download;
        private Label lbl_estimatedSizeValue;
        private ProgressBar pb_progress;
        private TextBox tb_ETA;
        private ComboBox cb_mode;
        private Button btn_openLog;
        private Button btn_delete;
    }
}
