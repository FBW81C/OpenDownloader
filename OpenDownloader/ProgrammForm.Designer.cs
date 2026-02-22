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
            SuspendLayout();
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
            textCredits.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            textCredits.AutoSize = true;
            textCredits.Location = new Point(652, 470);
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
            tbURL.Size = new Size(551, 23);
            tbURL.TabIndex = 4;
            // 
            // btnBrowseFolder
            // 
            btnBrowseFolder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBrowseFolder.Location = new Point(727, 19);
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
            tbFolder.Size = new Size(658, 23);
            tbFolder.TabIndex = 6;
            // 
            // btnDefault
            // 
            btnDefault.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDefault.Location = new Point(727, 45);
            btnDefault.Name = "btnDefault";
            btnDefault.Size = new Size(100, 23);
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
            flowLayoutPanel1.Location = new Point(12, 80);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(606, 382);
            flowLayoutPanel1.TabIndex = 21;
            flowLayoutPanel1.WrapContents = false;
            // 
            // btn_Add
            // 
            btn_Add.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_Add.Location = new Point(621, 19);
            btn_Add.Margin = new Padding(1);
            btn_Add.Name = "btn_Add";
            btn_Add.Size = new Size(103, 23);
            btn_Add.TabIndex = 22;
            btn_Add.Text = "Add Video";
            btn_Add.UseVisualStyleBackColor = true;
            btn_Add.Click += btn_Add_Click;
            // 
            // tb_output
            // 
            tb_output.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tb_output.Location = new Point(624, 80);
            tb_output.Multiline = true;
            tb_output.Name = "tb_output";
            tb_output.ReadOnly = true;
            tb_output.Size = new Size(203, 353);
            tb_output.TabIndex = 23;
            // 
            // btn_copyToClipboard
            // 
            btn_copyToClipboard.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btn_copyToClipboard.Location = new Point(624, 439);
            btn_copyToClipboard.Name = "btn_copyToClipboard";
            btn_copyToClipboard.Size = new Size(203, 23);
            btn_copyToClipboard.TabIndex = 24;
            btn_copyToClipboard.Text = "Copy To Clipboard";
            btn_copyToClipboard.UseVisualStyleBackColor = true;
            btn_copyToClipboard.Click += btn_copyToClipboard_Click;
            // 
            // ProgrammForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(841, 494);
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
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(1080, 969);
            MinimumSize = new Size(645, 404);
            Name = "ProgrammForm";
            Text = "OpenDownloader";
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
    }
}
