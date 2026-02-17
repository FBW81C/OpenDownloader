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
            btn_downloadAll = new Button();
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
            btn_Add = new Button();
            SuspendLayout();
            // 
            // btn_downloadAll
            // 
            btn_downloadAll.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_downloadAll.Enabled = false;
            btn_downloadAll.Location = new Point(2074, 1192);
            btn_downloadAll.Margin = new Padding(7, 8, 7, 8);
            btn_downloadAll.Name = "btn_downloadAll";
            btn_downloadAll.Size = new Size(241, 63);
            btn_downloadAll.TabIndex = 0;
            btn_downloadAll.Text = "Download All";
            btn_downloadAll.UseVisualStyleBackColor = true;
            btn_downloadAll.Click += btnDownloadAll_click;
            // 
            // textURL
            // 
            textURL.AutoSize = true;
            textURL.Location = new Point(32, 52);
            textURL.Margin = new Padding(7, 0, 7, 0);
            textURL.Name = "textURL";
            textURL.Size = new Size(71, 41);
            textURL.TabIndex = 1;
            textURL.Text = "URL";
            // 
            // textSaveTo
            // 
            textSaveTo.AutoSize = true;
            textSaveTo.Location = new Point(29, 123);
            textSaveTo.Margin = new Padding(7, 0, 7, 0);
            textSaveTo.Name = "textSaveTo";
            textSaveTo.Size = new Size(118, 41);
            textSaveTo.TabIndex = 2;
            textSaveTo.Text = "Save To";
            // 
            // textCredits
            // 
            textCredits.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textCredits.AutoSize = true;
            textCredits.Location = new Point(1911, 1386);
            textCredits.Margin = new Padding(7, 0, 7, 0);
            textCredits.Name = "textCredits";
            textCredits.Size = new Size(449, 41);
            textCredits.TabIndex = 3;
            textCredits.Text = "OpenDownloader © by FBW81C";
            // 
            // tbURL
            // 
            tbURL.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbURL.Location = new Point(160, 52);
            tbURL.Margin = new Padding(7, 8, 7, 8);
            tbURL.Name = "tbURL";
            tbURL.Size = new Size(1641, 47);
            tbURL.TabIndex = 4;
            // 
            // btnBrowseFolder
            // 
            btnBrowseFolder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBrowseFolder.Location = new Point(2074, 44);
            btnBrowseFolder.Margin = new Padding(7, 8, 7, 8);
            btnBrowseFolder.Name = "btnBrowseFolder";
            btnBrowseFolder.Size = new Size(243, 63);
            btnBrowseFolder.TabIndex = 5;
            btnBrowseFolder.Text = "Browse Folder";
            btnBrowseFolder.UseVisualStyleBackColor = true;
            btnBrowseFolder.Click += btnBrowseFolder_Click;
            // 
            // tbFolder
            // 
            tbFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbFolder.Location = new Point(160, 123);
            tbFolder.Margin = new Padding(7, 8, 7, 8);
            tbFolder.Name = "tbFolder";
            tbFolder.Size = new Size(1900, 47);
            tbFolder.TabIndex = 6;
            // 
            // pbDownload
            // 
            pbDownload.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pbDownload.Location = new Point(175, 1192);
            pbDownload.Margin = new Padding(7, 8, 7, 8);
            pbDownload.Name = "pbDownload";
            pbDownload.Size = new Size(1630, 63);
            pbDownload.TabIndex = 7;
            // 
            // textProgress
            // 
            textProgress.AutoSize = true;
            textProgress.Location = new Point(32, 1203);
            textProgress.Margin = new Padding(7, 0, 7, 0);
            textProgress.Name = "textProgress";
            textProgress.Size = new Size(133, 41);
            textProgress.TabIndex = 8;
            textProgress.Text = "Progress";
            // 
            // tbConsole
            // 
            tbConsole.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbConsole.BorderStyle = BorderStyle.FixedSingle;
            tbConsole.Location = new Point(1819, 219);
            tbConsole.Margin = new Padding(7, 8, 7, 8);
            tbConsole.Multiline = true;
            tbConsole.Name = "tbConsole";
            tbConsole.ReadOnly = true;
            tbConsole.ScrollBars = ScrollBars.Vertical;
            tbConsole.Size = new Size(486, 870);
            tbConsole.TabIndex = 9;
            tbConsole.WordWrap = false;
            // 
            // btnDefault
            // 
            btnDefault.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDefault.Location = new Point(2074, 123);
            btnDefault.Margin = new Padding(7, 8, 7, 8);
            btnDefault.Name = "btnDefault";
            btnDefault.Size = new Size(243, 63);
            btnDefault.TabIndex = 10;
            btnDefault.Text = "Set as default";
            btnDefault.UseVisualStyleBackColor = true;
            btnDefault.Click += btnDefault_Click;
            // 
            // tbETA
            // 
            tbETA.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tbETA.Location = new Point(1819, 1203);
            tbETA.Margin = new Padding(7, 8, 7, 8);
            tbETA.Name = "tbETA";
            tbETA.ReadOnly = true;
            tbETA.Size = new Size(241, 47);
            tbETA.TabIndex = 17;
            tbETA.Text = "ETA: N/A";
            // 
            // btn_CopyToClipboard
            // 
            btn_CopyToClipboard.Location = new Point(1819, 1109);
            btn_CopyToClipboard.Margin = new Padding(7, 8, 7, 8);
            btn_CopyToClipboard.Name = "btn_CopyToClipboard";
            btn_CopyToClipboard.Size = new Size(496, 63);
            btn_CopyToClipboard.TabIndex = 20;
            btn_CopyToClipboard.Text = "Copy to Clipboard";
            btn_CopyToClipboard.UseVisualStyleBackColor = true;
            btn_CopyToClipboard.Click += btnClipboard_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = SystemColors.ControlDark;
            flowLayoutPanel1.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(29, 219);
            flowLayoutPanel1.Margin = new Padding(7, 8, 7, 8);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1772, 953);
            flowLayoutPanel1.TabIndex = 21;
            flowLayoutPanel1.WrapContents = false;
            // 
            // btn_Add
            // 
            btn_Add.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_Add.Location = new Point(1811, 46);
            btn_Add.Name = "btn_Add";
            btn_Add.Size = new Size(249, 58);
            btn_Add.TabIndex = 22;
            btn_Add.Text = "Add Video";
            btn_Add.UseVisualStyleBackColor = true;
            btn_Add.Click += btn_Add_Click;
            // 
            // ProgrammForm
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2351, 1350);
            Controls.Add(btn_Add);
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
            Controls.Add(btn_downloadAll);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(7, 8, 7, 8);
            MaximumSize = new Size(2383, 2581);
            MinimumSize = new Size(1778, 1304);
            Name = "ProgrammForm";
            Text = "OpenDownloader";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_downloadAll;
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
        private Button btn_Add;
    }
}
