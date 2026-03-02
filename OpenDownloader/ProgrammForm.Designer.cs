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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgrammForm));
            textURL = new Label();
            textSaveTo = new Label();
            textCredits = new Label();
            tbURL = new TextBox();
            btnBrowseFolder = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            tbFolder = new TextBox();
            btnDefault = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btn_Add = new Button();
            tb_output = new TextBox();
            btn_copyToClipboard = new Button();
            menuStrip1 = new MenuStrip();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            gitHubToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem1 = new ToolStripMenuItem();
            notifyIcon1 = new NotifyIcon(components);
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // textURL
            // 
            textURL.AutoSize = true;
            textURL.Location = new Point(17, 52);
            textURL.Margin = new Padding(4, 0, 4, 0);
            textURL.Name = "textURL";
            textURL.Size = new Size(43, 25);
            textURL.TabIndex = 1;
            textURL.Text = "URL";
            // 
            // textSaveTo
            // 
            textSaveTo.AutoSize = true;
            textSaveTo.Location = new Point(17, 100);
            textSaveTo.Margin = new Padding(4, 0, 4, 0);
            textSaveTo.Name = "textSaveTo";
            textSaveTo.Size = new Size(72, 25);
            textSaveTo.TabIndex = 2;
            textSaveTo.Text = "Save To";
            // 
            // textCredits
            // 
            textCredits.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            textCredits.AutoSize = true;
            textCredits.Location = new Point(1043, 821);
            textCredits.Margin = new Padding(4, 0, 4, 0);
            textCredits.Name = "textCredits";
            textCredits.Size = new Size(271, 25);
            textCredits.TabIndex = 3;
            textCredits.Text = "OpenDownloader © by FBW81C";
            // 
            // tbURL
            // 
            tbURL.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbURL.Location = new Point(94, 47);
            tbURL.Margin = new Padding(4, 5, 4, 5);
            tbURL.Name = "tbURL";
            tbURL.Size = new Size(923, 31);
            tbURL.TabIndex = 4;
            // 
            // btnBrowseFolder
            // 
            btnBrowseFolder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBrowseFolder.Location = new Point(1179, 47);
            btnBrowseFolder.Margin = new Padding(4, 5, 4, 5);
            btnBrowseFolder.Name = "btnBrowseFolder";
            btnBrowseFolder.Size = new Size(143, 38);
            btnBrowseFolder.TabIndex = 5;
            btnBrowseFolder.Text = "Browse Folder";
            btnBrowseFolder.UseVisualStyleBackColor = true;
            btnBrowseFolder.Click += btnBrowseFolder_Click;
            // 
            // tbFolder
            // 
            tbFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbFolder.Location = new Point(94, 95);
            tbFolder.Margin = new Padding(4, 5, 4, 5);
            tbFolder.Name = "tbFolder";
            tbFolder.Size = new Size(1075, 31);
            tbFolder.TabIndex = 6;
            // 
            // btnDefault
            // 
            btnDefault.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDefault.Location = new Point(1179, 95);
            btnDefault.Margin = new Padding(4, 5, 4, 5);
            btnDefault.Name = "btnDefault";
            btnDefault.Size = new Size(143, 38);
            btnDefault.TabIndex = 10;
            btnDefault.Text = "Set as default";
            btnDefault.UseVisualStyleBackColor = true;
            btnDefault.Click += btnDefault_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = SystemColors.ControlDark;
            flowLayoutPanel1.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(17, 157);
            flowLayoutPanel1.Margin = new Padding(4, 5, 4, 5);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(925, 644);
            flowLayoutPanel1.TabIndex = 21;
            flowLayoutPanel1.WrapContents = false;
            // 
            // btn_Add
            // 
            btn_Add.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_Add.Location = new Point(1024, 47);
            btn_Add.Margin = new Padding(1, 2, 1, 2);
            btn_Add.Name = "btn_Add";
            btn_Add.Size = new Size(147, 38);
            btn_Add.TabIndex = 22;
            btn_Add.Text = "Add Video";
            btn_Add.UseVisualStyleBackColor = true;
            btn_Add.Click += btn_Add_Click;
            // 
            // tb_output
            // 
            tb_output.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tb_output.Location = new Point(951, 157);
            tb_output.Margin = new Padding(4, 5, 4, 5);
            tb_output.Multiline = true;
            tb_output.Name = "tb_output";
            tb_output.ReadOnly = true;
            tb_output.Size = new Size(365, 594);
            tb_output.TabIndex = 23;
            // 
            // btn_copyToClipboard
            // 
            btn_copyToClipboard.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn_copyToClipboard.Location = new Point(951, 763);
            btn_copyToClipboard.Margin = new Padding(4, 5, 4, 5);
            btn_copyToClipboard.Name = "btn_copyToClipboard";
            btn_copyToClipboard.Size = new Size(363, 38);
            btn_copyToClipboard.TabIndex = 24;
            btn_copyToClipboard.Text = "Copy To Clipboard";
            btn_copyToClipboard.UseVisualStyleBackColor = true;
            btn_copyToClipboard.Click += btn_copyToClipboard_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(9, 3, 0, 3);
            menuStrip1.Size = new Size(1339, 35);
            menuStrip1.TabIndex = 25;
            menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gitHubToolStripMenuItem, aboutToolStripMenuItem1 });
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(78, 29);
            aboutToolStripMenuItem.Text = "About";
            // 
            // gitHubToolStripMenuItem
            // 
            gitHubToolStripMenuItem.Name = "gitHubToolStripMenuItem";
            gitHubToolStripMenuItem.Size = new Size(310, 34);
            gitHubToolStripMenuItem.Text = "GitHub";
            gitHubToolStripMenuItem.Click += gitHubToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem1
            // 
            aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            aboutToolStripMenuItem1.Size = new Size(310, 34);
            aboutToolStripMenuItem1.Text = "About OpenDownloader";
            aboutToolStripMenuItem1.Click += aboutOpenClickerToolStripMenuItem_Click;
            // 
            // notifyIcon1
            // 
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Visible = true;
            // 
            // ProgrammForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1339, 855);
            Controls.Add(btn_copyToClipboard);
            Controls.Add(tb_output);
            Controls.Add(btn_Add);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(btnDefault);
            Controls.Add(tbFolder);
            Controls.Add(btnBrowseFolder);
            Controls.Add(tbURL);
            Controls.Add(textCredits);
            Controls.Add(textSaveTo);
            Controls.Add(textURL);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 5, 4, 5);
            MaximumSize = new Size(1533, 1578);
            MinimumSize = new Size(912, 636);
            Name = "ProgrammForm";
            Text = "OpenDownloader";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label textURL;
        private Label textSaveTo;
        private Label textCredits;
        private TextBox tbURL;
        private Button btnBrowseFolder;
        private FolderBrowserDialog folderBrowserDialog1;
        private TextBox tbFolder;
        private Button btnDefault;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btn_Add;
        private TextBox tb_output;
        private Button btn_copyToClipboard;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem gitHubToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem1;
        private NotifyIcon notifyIcon1;
    }
}
