namespace YouTubeDownloader
{
    partial class NotificationForm
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
            lblTitle = new Label();
            lblMessage = new Label();
            pictureBoxIcon = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial", 10F, FontStyle.Bold);
            lblTitle.Location = new Point(50, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(49, 16);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "label1";
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Font = new Font("Arial", 8F);
            lblMessage.Location = new Point(50, 30);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(35, 14);
            lblMessage.TabIndex = 1;
            lblMessage.Text = "label2";
            // 
            // pictureBoxIcon
            // 
            pictureBoxIcon.Location = new Point(10, 10);
            pictureBoxIcon.Name = "pictureBoxIcon";
            pictureBoxIcon.Size = new Size(32, 32);
            pictureBoxIcon.TabIndex = 2;
            pictureBoxIcon.TabStop = false;
            // 
            // NotificationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(197, 76);
            Controls.Add(pictureBoxIcon);
            Controls.Add(lblMessage);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "NotificationForm";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "NotificationForm";
            Load += NotificationForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblMessage;
        private PictureBox pictureBoxIcon;
    }
}