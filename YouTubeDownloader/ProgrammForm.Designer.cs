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
            SuspendLayout();
            // 
            // btnDownload
            // 
            btnDownload.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDownload.Location = new Point(672, 461);
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
            textCredits.Location = new Point(578, 507);
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
            tbURL.Size = new Size(697, 23);
            tbURL.TabIndex = 4;
            // 
            // btnBrowseFolder
            // 
            btnBrowseFolder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBrowseFolder.Location = new Point(577, 64);
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
            tbFolder.Size = new Size(496, 23);
            tbFolder.TabIndex = 6;
            // 
            // pbDownload
            // 
            pbDownload.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pbDownload.Location = new Point(75, 461);
            pbDownload.Name = "pbDownload";
            pbDownload.Size = new Size(591, 23);
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
            tbConsole.Location = new Point(12, 106);
            tbConsole.Multiline = true;
            tbConsole.Name = "tbConsole";
            tbConsole.ReadOnly = true;
            tbConsole.Size = new Size(760, 349);
            tbConsole.TabIndex = 9;
            // 
            // btnDefault
            // 
            btnDefault.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDefault.Location = new Point(683, 64);
            btnDefault.Name = "btnDefault";
            btnDefault.Size = new Size(89, 23);
            btnDefault.TabIndex = 10;
            btnDefault.Text = "Set as default";
            btnDefault.UseVisualStyleBackColor = true;
            btnDefault.Click += btnDefault_Click;
            // 
            // ProgrammForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 531);
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
            MinimumSize = new Size(680, 570);
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
    }
}
