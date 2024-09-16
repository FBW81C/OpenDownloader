namespace YouTubeDownloader
{
    partial class InstallForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnInstall = new Button();
            btnExit = new Button();
            pbInstall = new ProgressBar();
            textProgress = new Label();
            textWelcome = new Label();
            textDependency = new Label();
            SuspendLayout();
            // 
            // btnInstall
            // 
            btnInstall.Location = new Point(299, 132);
            btnInstall.Name = "btnInstall";
            btnInstall.Size = new Size(75, 23);
            btnInstall.TabIndex = 0;
            btnInstall.Text = "Install";
            btnInstall.UseVisualStyleBackColor = true;
            btnInstall.Click += btnInstall_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(218, 132);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 23);
            btnExit.TabIndex = 1;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // pbInstall
            // 
            pbInstall.Location = new Point(13, 103);
            pbInstall.Name = "pbInstall";
            pbInstall.Size = new Size(361, 23);
            pbInstall.TabIndex = 2;
            // 
            // textProgress
            // 
            textProgress.AutoSize = true;
            textProgress.Location = new Point(13, 85);
            textProgress.Name = "textProgress";
            textProgress.Size = new Size(55, 15);
            textProgress.TabIndex = 3;
            textProgress.Text = "Progress:";
            // 
            // textWelcome
            // 
            textWelcome.AutoSize = true;
            textWelcome.Location = new Point(12, 9);
            textWelcome.Name = "textWelcome";
            textWelcome.Size = new Size(247, 15);
            textWelcome.TabIndex = 4;
            textWelcome.Text = "Welcome to YouTubeDownloader by FBW81C";
            // 
            // textDependency
            // 
            textDependency.AutoSize = true;
            textDependency.Location = new Point(12, 40);
            textDependency.Name = "textDependency";
            textDependency.Size = new Size(262, 30);
            textDependency.TabIndex = 5;
            textDependency.Text = "This Application uses: yt-dlp.exe as dependency.\r\nRepository: https://github.com/yt-dlp/yt-dlp";
            // 
            // InstallForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(386, 163);
            Controls.Add(textDependency);
            Controls.Add(textWelcome);
            Controls.Add(textProgress);
            Controls.Add(pbInstall);
            Controls.Add(btnExit);
            Controls.Add(btnInstall);
            Name = "InstallForm";
            Text = "InstallForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnInstall;
        private Button btnExit;
        private ProgressBar pbInstall;
        private Label textProgress;
        private Label textWelcome;
        private Label textDependency;
    }
}