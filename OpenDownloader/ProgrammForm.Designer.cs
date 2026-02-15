namespace OpenDownloader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgrammForm));
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
            tbETA = new TextBox();
            btn_CopyToClipboard = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            button1 = new Button();
            SuspendLayout();
            // 
            // btnDownload
            // 
            btnDownload.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDownload.Enabled = false;
            btnDownload.Location = new Point(869, 436);
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
            textURL.Location = new Point(13, 19);
            textURL.Name = "textURL";
            textURL.Size = new Size(28, 15);
            textURL.TabIndex = 1;
            textURL.Text = "URL";
            // 
            // textSaveTo
            // 
            textSaveTo.AutoSize = true;
            textSaveTo.Location = new Point(12, 45);
            textSaveTo.Name = "textSaveTo";
            textSaveTo.Size = new Size(46, 15);
            textSaveTo.TabIndex = 2;
            textSaveTo.Text = "Save To";
            // 
            // textCredits
            // 
            textCredits.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textCredits.AutoSize = true;
            textCredits.Location = new Point(787, 507);
            textCredits.Name = "textCredits";
            textCredits.Size = new Size(177, 15);
            textCredits.TabIndex = 3;
            textCredits.Text = "OpenDownloader © by FBW81C";
            // 
            // tbURL
            // 
            tbURL.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbURL.Location = new Point(66, 19);
            tbURL.Name = "tbURL";
            tbURL.Size = new Size(801, 23);
            tbURL.TabIndex = 4;
            tbURL.Leave += tbURL_Leave;
            // 
            // btnBrowseFolder
            // 
            btnBrowseFolder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBrowseFolder.Location = new Point(870, 16);
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
            tbFolder.Location = new Point(66, 45);
            tbFolder.Name = "tbFolder";
            tbFolder.Size = new Size(801, 23);
            tbFolder.TabIndex = 6;
            // 
            // pbDownload
            // 
            pbDownload.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pbDownload.Location = new Point(72, 436);
            pbDownload.Name = "pbDownload";
            pbDownload.Size = new Size(671, 23);
            pbDownload.TabIndex = 7;
            // 
            // textProgress
            // 
            textProgress.AutoSize = true;
            textProgress.Location = new Point(13, 440);
            textProgress.Name = "textProgress";
            textProgress.Size = new Size(52, 15);
            textProgress.TabIndex = 8;
            textProgress.Text = "Progress";
            // 
            // tbConsole
            // 
            tbConsole.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbConsole.Location = new Point(749, 74);
            tbConsole.Multiline = true;
            tbConsole.Name = "tbConsole";
            tbConsole.ReadOnly = true;
            tbConsole.Size = new Size(220, 327);
            tbConsole.TabIndex = 9;
            // 
            // btnDefault
            // 
            btnDefault.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDefault.Location = new Point(870, 45);
            btnDefault.Name = "btnDefault";
            btnDefault.Size = new Size(100, 23);
            btnDefault.TabIndex = 10;
            btnDefault.Text = "Set as default";
            btnDefault.UseVisualStyleBackColor = true;
            btnDefault.Click += btnDefault_Click;
            // 
            // tbETA
            // 
            tbETA.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tbETA.Location = new Point(749, 436);
            tbETA.Name = "tbETA";
            tbETA.ReadOnly = true;
            tbETA.Size = new Size(118, 23);
            tbETA.TabIndex = 17;
            tbETA.Text = "ETA: N/A";
            // 
            // btn_CopyToClipboard
            // 
            btn_CopyToClipboard.Location = new Point(848, 407);
            btn_CopyToClipboard.Name = "btn_CopyToClipboard";
            btn_CopyToClipboard.Size = new Size(121, 23);
            btn_CopyToClipboard.TabIndex = 20;
            btn_CopyToClipboard.Text = "Copy to Clipboard";
            btn_CopyToClipboard.UseVisualStyleBackColor = true;
            btn_CopyToClipboard.Click += btnClipboard_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(12, 80);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(731, 350);
            flowLayoutPanel1.TabIndex = 21;
            flowLayoutPanel1.WrapContents = false;
            // 
            // button1
            // 
            button1.Location = new Point(749, 407);
            button1.Name = "button1";
            button1.Size = new Size(93, 23);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // ProgrammForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 494);
            Controls.Add(button1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(btn_CopyToClipboard);
            Controls.Add(tbETA);
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
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(1000, 1000);
            MinimumSize = new Size(751, 533);
            Name = "ProgrammForm";
            Text = "OpenDownloader";
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
        private TextBox tbETA;
        private Button btn_CopyToClipboard;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button button1;
    }
}
