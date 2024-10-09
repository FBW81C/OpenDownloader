using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace YouTubeDownloader
{
    public partial class NotificationForm : Form
    {
        private System.Timers.Timer closeTimer;

        public NotificationForm(string title, string titleText, string message, Icon icon)
        {
            InitializeComponent();
            this.Text = title;
            lblTitle.Text = titleText;
            lblMessage.Text = message;
            pictureBoxIcon.Image = icon.ToBitmap();

            this.StartPosition = FormStartPosition.Manual;
            var screen = Screen.PrimaryScreen.WorkingArea;
            this.Location = new Point(screen.Width - this.Width - 10, screen.Height - this.Height - 10);

            closeTimer = new System.Timers.Timer(5000);  // 5 Seconds
            closeTimer.Elapsed += CloseTimer_Elapsed;
            closeTimer.Start();
        }

        private void CloseTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                closeTimer.Stop();
                this.Close();
            });
        }

        private void NotificationForm_Load(object sender, EventArgs e)
        {

        }
    }
}
