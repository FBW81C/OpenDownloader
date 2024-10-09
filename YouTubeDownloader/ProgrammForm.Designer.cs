namespace YouTubeDownloader
{
    partial class ProgrammForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnDownload = new Button();
            textURL = new Label();
            textSaveTo = new Label();
            textCredits = new Label();
            tbURL = new TextBox();
            btnBrowseFolder = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            tbFolder = new TextBox();
            pbDownload = new ProgressBar();
            textProgress = new Label();
            tbConsole = new TextBox();
            btnDefault = new Button();
            cbQuality = new ComboBox();
            textQuality = new Label();
            textFPS = new Label();
            textFormat = new Label();
            cbFPS = new ComboBox();
            cbFormat = new ComboBox();
            tbETA = new TextBox();
            tbFilesize = new TextBox();
            textEstimatedSize = new Label();
            SuspendLayout();
            // 
            // btnDownload
            // 
            btnDownload.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDownload.Enabled = false;
            btnDownload.Location = new Point(872, 461);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(100, 23);
            btnDownload.TabIndex = 0;
            btnDownload.Text = "Download";
            btnDownload.UseVisualStyleBackColor = true;
            btnDownload.Click += buttonDownoad;
            // 
            // textURL
            // 
            textURL.AutoSize = true;
            textURL.Location = new Point(12, 21);
            textURL.Name = "textURL";
            textURL.Size = new Size(28, 15);
            textURL.TabIndex = 1;
            textURL.Text = "URL";
            // 
            // textSaveTo
            // 
            textSaveTo.AutoSize = true;
            textSaveTo.Location = new Point(12, 68);
            textSaveTo.Name = "textSaveTo";
            textSaveTo.Size = new Size(46, 15);
            textSaveTo.TabIndex = 2;
            textSaveTo.Text = "Save To";
            // 
            // textCredits
            // 
            textCredits.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textCredits.AutoSize = true;
            textCredits.Location = new Point(778, 507);
            textCredits.Name = "textCredits";
            textCredits.Size = new Size(194, 15);
            textCredits.TabIndex = 3;
            textCredits.Text = "YouTubeDownloader © by FBW81C";
            // 
            // tbURL
            // 
            tbURL.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbURL.Location = new Point(75, 18);
            tbURL.Name = "tbURL";
            tbURL.Size = new Size(897, 23);
            tbURL.TabIndex = 4;
            tbURL.Leave += tbURL_Leave;
            // 
            // btnBrowseFolder
            // 
            btnBrowseFolder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBrowseFolder.Location = new Point(777, 64);
            btnBrowseFolder.Name = "btnBrowseFolder";
            btnBrowseFolder.Size = new Size(100, 23);
            btnBrowseFolder.TabIndex = 5;
            btnBrowseFolder.Text = "Browse Folder";
            btnBrowseFolder.UseVisualStyleBackColor = true;
            btnBrowseFolder.Click += btnBrowseFolder_Click;
            // 
            // tbFolder
            // 
            tbFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbFolder.Location = new Point(75, 64);
            tbFolder.Name = "tbFolder";
            tbFolder.Size = new Size(696, 23);
            tbFolder.TabIndex = 6;
            // 
            // pbDownload
            // 
            pbDownload.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pbDownload.Location = new Point(75, 461);
            pbDownload.Name = "pbDownload";
            pbDownload.Size = new Size(723, 23);
            pbDownload.TabIndex = 7;
            // 
            // textProgress
            // 
            textProgress.AutoSize = true;
            textProgress.Location = new Point(12, 465);
            textProgress.Name = "textProgress";
            textProgress.Size = new Size(52, 15);
            textProgress.TabIndex = 8;
            textProgress.Text = "Progress";
            // 
            // tbConsole
            // 
            tbConsole.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbConsole.Location = new Point(12, 145);
            tbConsole.Multiline = true;
            tbConsole.Name = "tbConsole";
            tbConsole.ReadOnly = true;
            tbConsole.Size = new Size(960, 310);
            tbConsole.TabIndex = 9;
            // 
            // btnDefault
            // 
            btnDefault.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDefault.Location = new Point(883, 64);
            btnDefault.Name = "btnDefault";
            btnDefault.Size = new Size(89, 23);
            btnDefault.TabIndex = 10;
            btnDefault.Text = "Set as default";
            btnDefault.UseVisualStyleBackColor = true;
            btnDefault.Click += btnDefault_Click;
            // 
            // cbQuality
            // 
            cbQuality.Enabled = false;
            cbQuality.FormattingEnabled = true;
            cbQuality.Location = new Point(257, 103);
            cbQuality.Name = "cbQuality";
            cbQuality.Size = new Size(121, 23);
            cbQuality.TabIndex = 11;
            cbQuality.Text = "N/A";
            cbQuality.SelectedValueChanged += cbQuality_SelectedValueChanged;
            cbQuality.KeyPress += cb_KeyPress;
            // 
            // textQuality
            // 
            textQuality.AutoSize = true;
            textQuality.Location = new Point(206, 106);
            textQuality.Name = "textQuality";
            textQuality.Size = new Size(45, 15);
            textQuality.TabIndex = 12;
            textQuality.Text = "Quality";
            // 
            // textFPS
            // 
            textFPS.AutoSize = true;
            textFPS.Location = new Point(384, 106);
            textFPS.Name = "textFPS";
            textFPS.Size = new Size(26, 15);
            textFPS.TabIndex = 13;
            textFPS.Text = "FPS";
            // 
            // textFormat
            // 
            textFormat.AutoSize = true;
            textFormat.Location = new Point(13, 106);
            textFormat.Name = "textFormat";
            textFormat.Size = new Size(45, 15);
            textFormat.TabIndex = 14;
            textFormat.Text = "Format";
            // 
            // cbFPS
            // 
            cbFPS.Enabled = false;
            cbFPS.FormattingEnabled = true;
            cbFPS.Location = new Point(416, 103);
            cbFPS.Name = "cbFPS";
            cbFPS.Size = new Size(121, 23);
            cbFPS.TabIndex = 15;
            cbFPS.Text = "N/A";
            cbFPS.KeyPress += cb_KeyPress;
            // 
            // cbFormat
            // 
            cbFormat.Enabled = false;
            cbFormat.FormattingEnabled = true;
            cbFormat.Location = new Point(75, 103);
            cbFormat.Name = "cbFormat";
            cbFormat.Size = new Size(121, 23);
            cbFormat.TabIndex = 16;
            cbFormat.Text = "N/A";
            cbFormat.KeyPress += cb_KeyPress;
            // 
            // tbETA
            // 
            tbETA.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tbETA.Location = new Point(804, 461);
            tbETA.Name = "tbETA";
            tbETA.ReadOnly = true;
            tbETA.Size = new Size(62, 23);
            tbETA.TabIndex = 17;
            tbETA.Text = "ETA: N/A";
            // 
            // tbFilesize
            // 
            tbFilesize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tbFilesize.Location = new Point(872, 103);
            tbFilesize.Name = "tbFilesize";
            tbFilesize.ReadOnly = true;
            tbFilesize.Size = new Size(100, 23);
            tbFilesize.TabIndex = 18;
            tbFilesize.Text = "N/A";
            // 
            // textEstimatedSize
            // 
            textEstimatedSize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textEstimatedSize.AutoSize = true;
            textEstimatedSize.Location = new Point(784, 106);
            textEstimatedSize.Name = "textEstimatedSize";
            textEstimatedSize.Size = new Size(82, 15);
            textEstimatedSize.TabIndex = 19;
            textEstimatedSize.Text = "Estimated Size";
            // 
            // ProgrammForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 531);
            Controls.Add(textEstimatedSize);
            Controls.Add(tbFilesize);
            Controls.Add(tbETA);
            Controls.Add(cbFormat);
            Controls.Add(cbFPS);
            Controls.Add(textFormat);
            Controls.Add(textFPS);
            Controls.Add(textQuality);
            Controls.Add(cbQuality);
            Controls.Add(btnDefault);
            Controls.Add(tbConsole);
            Controls.Add(textProgress);
            Controls.Add(pbDownload);
            Controls.Add(tbFolder);
            Controls.Add(btnBrowseFolder);
            Controls.Add(tbURL);
            Controls.Add(textCredits);
            Controls.Add(textSaveTo);
            Controls.Add(textURL);
            Controls.Add(btnDownload);
            MaximumSize = new Size(1000, 570);
            MinimumSize = new Size(760, 570);
            Name = "ProgrammForm";
            Text = "YouTubeDownloader";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDownload;
        private Label textURL;
        private Label textSaveTo;
        private Label textCredits;
        private TextBox tbURL;
        private Button btnBrowseFolder;
        private FolderBrowserDialog folderBrowserDialog1;
        private TextBox tbFolder;
        private ProgressBar pbDownload;
        private Label textProgress;
        private TextBox tbConsole;
        private Button btnDefault;
        private ComboBox cbQuality;
        private Label textQuality;
        private Label textFPS;
        private Label textFormat;
        private ComboBox cbFPS;
        private ComboBox cbFormat;
        private TextBox tbETA;
        private TextBox tbFilesize;
        private Label textEstimatedSize;
    }
}
