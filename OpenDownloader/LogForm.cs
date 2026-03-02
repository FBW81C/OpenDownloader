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
    }
}
