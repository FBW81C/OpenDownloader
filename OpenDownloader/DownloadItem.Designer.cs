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
            lbl_estimatedSize = new Label();
            lbl_estimatedSizeValue = new Label();
            ((System.ComponentModel.ISupportInitialize)pb_thumbnail).BeginInit();
            SuspendLayout();
            // 
            // pb_thumbnail
            // 
            pb_thumbnail.Location = new Point(-1, -1);
            pb_thumbnail.Margin = new Padding(7, 8, 7, 8);
            pb_thumbnail.Name = "pb_thumbnail";
            pb_thumbnail.Size = new Size(257, 182);
            pb_thumbnail.SizeMode = PictureBoxSizeMode.Zoom;
            pb_thumbnail.TabIndex = 0;
            pb_thumbnail.TabStop = false;
            // 
            // lbl_title
            // 
            lbl_title.AutoSize = true;
            lbl_title.Location = new Point(270, 33);
            lbl_title.Margin = new Padding(7, 0, 7, 0);
            lbl_title.Name = "lbl_title";
            lbl_title.Size = new Size(97, 41);
            lbl_title.TabIndex = 1;
            lbl_title.Text = "label1";
            // 
            // cb_quality
            // 
            cb_quality.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_quality.FormattingEnabled = true;
            cb_quality.Location = new Point(270, 96);
            cb_quality.Margin = new Padding(7, 8, 7, 8);
            cb_quality.Name = "cb_quality";
            cb_quality.Size = new Size(288, 49);
            cb_quality.TabIndex = 2;
            cb_quality.SelectedValueChanged += cb_quality_SelectedValueChanged;
            // 
            // cb_fps
            // 
            cb_fps.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_fps.FormattingEnabled = true;
            cb_fps.Location = new Point(578, 96);
            cb_fps.Margin = new Padding(7, 8, 7, 8);
            cb_fps.Name = "cb_fps";
            cb_fps.Size = new Size(288, 49);
            cb_fps.TabIndex = 3;
            // 
            // btn_download
            // 
            btn_download.Location = new Point(886, 93);
            btn_download.Margin = new Padding(7, 8, 7, 8);
            btn_download.Name = "btn_download";
            btn_download.Size = new Size(182, 63);
            btn_download.TabIndex = 4;
            btn_download.Text = "Download";
            btn_download.UseVisualStyleBackColor = true;
            btn_download.Click += btnDownload_Click;
            // 
            // lbl_estimatedSize
            // 
            lbl_estimatedSize.AutoSize = true;
            lbl_estimatedSize.Location = new Point(1090, 33);
            lbl_estimatedSize.Margin = new Padding(7, 0, 7, 0);
            lbl_estimatedSize.Name = "lbl_estimatedSize";
            lbl_estimatedSize.Size = new Size(206, 41);
            lbl_estimatedSize.TabIndex = 5;
            lbl_estimatedSize.Text = "Estimated size";
            // 
            // lbl_estimatedSizeValue
            // 
            lbl_estimatedSizeValue.AutoSize = true;
            lbl_estimatedSizeValue.Location = new Point(1090, 104);
            lbl_estimatedSizeValue.Margin = new Padding(7, 0, 7, 0);
            lbl_estimatedSizeValue.Name = "lbl_estimatedSizeValue";
            lbl_estimatedSizeValue.Size = new Size(97, 41);
            lbl_estimatedSizeValue.TabIndex = 6;
            lbl_estimatedSizeValue.Text = "label1";
            // 
            // DownloadItem
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Menu;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(lbl_estimatedSizeValue);
            Controls.Add(lbl_estimatedSize);
            Controls.Add(btn_download);
            Controls.Add(cb_fps);
            Controls.Add(cb_quality);
            Controls.Add(lbl_title);
            Controls.Add(pb_thumbnail);
            Margin = new Padding(7, 8, 7, 8);
            Name = "DownloadItem";
            Size = new Size(1413, 180);
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
        private Label lbl_estimatedSize;
        private Label lbl_estimatedSizeValue;
    }
}
