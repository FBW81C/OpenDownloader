using OpenDownloader.lib;
using OpenDownloader.model;
using System.Text.RegularExpressions;

namespace OpenDownloader
{
    public partial class DownloadItem : UserControl
    {
        public Image Thumbnail { get => pb_thumbnail.Image; }
        public string Title { get => lbl_title.Text; }
        public Video Video;
        public VideoOption SelectedVideoOption;

        // Controls
        public ProgressBar ProgressBar { get { return pb_progress; } }
        // Actions
        public event Func<object?, DownloadRequest, Task>? DownloadClicked;

        public DownloadItem(Video video)
        {
            InitializeComponent();

            Video = video;

            pb_thumbnail.Image = video.Thumbnail;
            lbl_title.Text = video.Title;

            // Resolutions
            cb_quality.Items.Clear();
            cb_quality.Items.AddRange(video.Options.ToArray());
            cb_quality.DisplayMember = "Resolution";
            if (cb_quality.Items.Count > 0)
            {
                var startOption = video.Options[0];
                cb_quality.SelectedItem = startOption;
                SelectedVideoOption = startOption;
            }

            // FPS
            if (cb_quality.Items.Count > 0)
            {
                var fps = video.Options[0].Fps;
                cb_fps.Items.Clear();
                cb_fps.Items.AddRange([fps]);
                cb_fps.SelectedIndex = 0;
            }

            // Download Mode
            var modes = new Dictionary<DownloadMode, string>() 
            {
                { DownloadMode.VideoWithAudio, "Video + Audio"},
                { DownloadMode.VideoOnly, "Video"},
                { DownloadMode.AudioOnly, "Audio"},
            };
            cb_mode.Items.Clear();
            cb_mode.DataSource = Enum.GetValues(typeof(DownloadMode));
            cb_mode.SelectedItem = DownloadMode.VideoWithAudio;
        }

        private async void btnDownload_Click(object sender, EventArgs e)
        {
            btn_download.Enabled = false;
            btn_download.Text = "Loading...";

            if (DownloadClicked != null && SelectedVideoOption != null)
            {
                var mode = (DownloadMode)cb_mode.SelectedItem;
                var request = new DownloadRequest
                {
                    Video = Video,
                    Option = SelectedVideoOption,
                    Mode = mode
                };

                await DownloadClicked(this, request);
            }

            btn_download.Enabled = true;
            btn_download.Text = "Download";
        }

        private void cb_quality_SelectedValueChanged(object sender, EventArgs e)
        {
            var option = cb_quality.SelectedItem as VideoOption;

            if (option == null)
            {
                throw new ArgumentException("Could should not get here");
            }

            SelectedVideoOption = option;

            cb_fps.Items.Clear();
            cb_fps.Items.AddRange([option.Fps]);
            cb_fps.SelectedIndex = 0;

            lbl_estimatedSizeValue.Text = option.EstimatedSize.HasValue ? FilesizeParser.ReadableFileSize(option.EstimatedSize.Value) : "N/A";
        }

        public void SetETA(string data)
        {
            Regex regex = new Regex("ETA *\\d{2}:\\d{2}");
            Match match = regex.Match(data);
            if (match.Success)
            {
                tb_ETA.Text = match.Value;
            }
        }
    }
}
