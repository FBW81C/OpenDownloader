using OpenDownloader.lib;
using OpenDownloader.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Design.AxImporter;

namespace OpenDownloader
{
    public partial class DownloadItem : UserControl
    {
        public Image Thumbnail { get => pb_thumbnail.Image; }
        public string Title { get => lbl_title.Text; }
        public Video Video;
        public VideoOption SelectedVideoOption;

        public DownloadItem(Video video)
        {
            InitializeComponent();

            Video = video;

            pb_thumbnail.Image = video.Thumbnail;
            lbl_title.Text = video.Title;

            // Resolutions
            //var qualities = video.Options.Select(o => o.Resolution).ToArray();
            cb_quality.Items.Clear();
            cb_quality.Items.AddRange(video.Options.ToArray());
            cb_quality.DisplayMember = "Resolution";
            if (cb_quality.Items.Count > 0)
                cb_quality.SelectedIndex = 0;

            // FPS
            if (cb_quality.Items.Count > 0)
            {
                var fps = video.Options[0].Fps;
                cb_fps.Items.Clear();
                cb_fps.Items.AddRange([fps]);
                cb_fps.SelectedIndex = 0;
            }
        }

        public event EventHandler<VideoOption>? DownloadClicked;

        private void btnDownload_Click(object sender, EventArgs e)
        {
            DownloadClicked?.Invoke(this, Video.Options[0]); // For test reasons [0]
        }

        private void cb_quality_SelectedValueChanged(object sender, EventArgs e)
        {
            var option = cb_quality.SelectedItem as VideoOption;

            if (option == null)
            {
                throw new ArgumentException("Could should not get here");
            }

            cb_fps.Items.Clear();
            cb_fps.Items.AddRange([option.Fps]);
            cb_fps.SelectedIndex = 0;

            lbl_estimatedSizeValue.Text = option.EstimatedSize.HasValue ? FilesizeParser.ReadableFileSize(option.EstimatedSize.Value) : "N/A";
        }
    }
}
