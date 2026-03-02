namespace OpenDownloader
{
    partial class LogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogForm));
            rtb_log = new RichTextBox();
            btn_clipboard = new Button();
            btn_save = new Button();
            lbl_log = new Label();
            lbl_title = new Label();
            SuspendLayout();
            // 
            // rtb_log
            // 
            rtb_log.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtb_log.Location = new Point(12, 57);
            rtb_log.Name = "rtb_log";
            rtb_log.ReadOnly = true;
            rtb_log.Size = new Size(776, 341);
            rtb_log.TabIndex = 0;
            rtb_log.Text = "";
            // 
            // btn_clipboard
            // 
            btn_clipboard.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_clipboard.Location = new Point(611, 404);
            btn_clipboard.Name = "btn_clipboard";
            btn_clipboard.Size = new Size(177, 34);
            btn_clipboard.TabIndex = 1;
            btn_clipboard.Text = "Copy to Clipboard";
            btn_clipboard.UseVisualStyleBackColor = true;
            // 
            // btn_save
            // 
            btn_save.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_save.Location = new Point(493, 404);
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(112, 34);
            btn_save.TabIndex = 2;
            btn_save.Text = "Save";
            btn_save.UseVisualStyleBackColor = true;
            // 
            // lbl_log
            // 
            lbl_log.AutoSize = true;
            lbl_log.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_log.Location = new Point(12, 9);
            lbl_log.Name = "lbl_log";
            lbl_log.Size = new Size(63, 32);
            lbl_log.TabIndex = 3;
            lbl_log.Text = "Log:";
            // 
            // lbl_title
            // 
            lbl_title.AutoSize = true;
            lbl_title.Location = new Point(81, 15);
            lbl_title.Name = "lbl_title";
            lbl_title.Size = new Size(59, 25);
            lbl_title.TabIndex = 4;
            lbl_title.Text = "label1";
            // 
            // LogForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lbl_title);
            Controls.Add(lbl_log);
            Controls.Add(btn_save);
            Controls.Add(btn_clipboard);
            Controls.Add(rtb_log);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(822, 506);
            MinimumSize = new Size(400, 400);
            Name = "LogForm";
            Text = "Download Log";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox rtb_log;
        private Button btn_clipboard;
        private Button btn_save;
        private Label lbl_log;
        private Label lbl_title;
    }
}