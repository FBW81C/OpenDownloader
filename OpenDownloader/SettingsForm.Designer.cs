namespace OpenDownloader
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            btn_save = new Button();
            btn_cancel = new Button();
            SuspendLayout();
            // 
            // btn_save
            // 
            btn_save.Location = new Point(600, 380);
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(188, 58);
            btn_save.TabIndex = 0;
            btn_save.Text = "Save";
            btn_save.UseVisualStyleBackColor = true;
            // 
            // btn_cancel
            // 
            btn_cancel.Location = new Point(406, 380);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.Size = new Size(188, 58);
            btn_cancel.TabIndex = 1;
            btn_cancel.Text = "Cancel";
            btn_cancel.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            AcceptButton = btn_save;
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btn_cancel;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_cancel);
            Controls.Add(btn_save);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SettingsForm";
            Text = "OpenDownloader Settings";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_save;
        private Button btn_cancel;
    }
}