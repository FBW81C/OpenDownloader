using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenDownloader
{
    public partial class LogForm : Form
    {
        public LogForm(string title)
        {
            InitializeComponent();

            lbl_title.Text = title;
        }

        public void Append(string text)
        {
            if (InvokeRequired)
                Invoke(new Action<string>(Append), text);
            else
                rtb_log.AppendText(text + Environment.NewLine);
        }

        private void btn_clipboard_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rtb_log.Text))
                return;

            Clipboard.SetText(rtb_log.Text);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            var result = saveFileDialog.ShowDialog();

            if (result != DialogResult.OK)
                return;

            var path = saveFileDialog.FileName;

            try
            {
                File.WriteAllText(path, rtb_log.Text);
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
