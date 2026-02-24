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
            ((System.ComponentModel.ISupportInitialize)pb_thumbnail).BeginInit();
            SuspendLayout();
            // 
            // pb_thumbnail
            // 
            pb_thumbnail.Location = new Point(0, 0);
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
            cb_quality.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_quality.FormattingEnabled = true;
            cb_quality.Location = new Point(142, 34);
            cb_quality.Name = "cb_quality";
            cb_quality.Size = new Size(121, 23);
            cb_quality.TabIndex = 2;
            cb_quality.SelectedValueChanged += cb_quality_SelectedValueChanged;
            // 
            // cb_fps
            // 
            cb_fps.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_fps.FormattingEnabled = true;
            cb_fps.Location = new Point(301, 34);
            cb_fps.Name = "cb_fps";
            cb_fps.Size = new Size(121, 23);
            cb_fps.TabIndex = 3;
            // 
            // btn_download
            // 
            btn_download.Location = new Point(560, 31);
            btn_download.Name = "btn_download";
            btn_download.Size = new Size(75, 23);
            btn_download.TabIndex = 4;
            btn_download.Text = "Download";
            btn_download.UseVisualStyleBackColor = true;
            btn_download.Click += btnDownload_Click;
            // 
            // lbl_estimatedSizeValue
            // 
            lbl_estimatedSizeValue.AutoSize = true;
            lbl_estimatedSizeValue.Location = new Point(558, 13);
            lbl_estimatedSizeValue.Name = "lbl_estimatedSizeValue";
            lbl_estimatedSizeValue.Size = new Size(38, 15);
            lbl_estimatedSizeValue.TabIndex = 6;
            lbl_estimatedSizeValue.Text = "label1";
            // 
            // pb_progress
            // 
            pb_progress.Location = new Point(142, 63);
            pb_progress.Name = "pb_progress";
            pb_progress.Size = new Size(411, 10);
            pb_progress.TabIndex = 7;
            // 
            // tb_ETA
            // 
            tb_ETA.Location = new Point(558, 55);
            tb_ETA.Name = "tb_ETA";
            tb_ETA.ReadOnly = true;
            tb_ETA.Size = new Size(76, 23);
            tb_ETA.TabIndex = 8;
            tb_ETA.Text = "ETA: N/A";
            // 
            // lbl_FPS
            // 
            lbl_FPS.AutoSize = true;
            lbl_FPS.Location = new Point(269, 37);
            lbl_FPS.Name = "lbl_FPS";
            lbl_FPS.Size = new Size(26, 15);
            lbl_FPS.TabIndex = 9;
            lbl_FPS.Text = "FPS";
            // 
            // cb_mode
            // 
            cb_mode.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_mode.FormattingEnabled = true;
            cb_mode.Location = new Point(426, 34);
            cb_mode.Margin = new Padding(2);
            cb_mode.Name = "cb_mode";
            cb_mode.Size = new Size(129, 23);
            cb_mode.TabIndex = 10;
            // 
            // DownloadItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Menu;
            BorderStyle = BorderStyle.FixedSingle;
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
            Name = "DownloadItem";
            Size = new Size(643, 83);
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
    }
}
