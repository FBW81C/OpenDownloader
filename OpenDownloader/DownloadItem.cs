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

        // Log
        private LogForm logWindow;
        List<string> logBuffer = new();


        // Actions
        public event Func<object?, DownloadRequest, Task>? DownloadClicked;

        public DownloadItem(Video video)
        {
            InitializeComponent();

            Video = video;

            pb_thumbnail.Image = video.Thumbnail;
            lbl_title.Text = video.Title;

            // Resolutions
            var startOption = video.Options[0];

            cb_quality.Items.Clear();
            cb_quality.Items.AddRange(video.Options.ToArray());
            cb_quality.DisplayMember = "Resolution";
            if (cb_quality.Items.Count > 0)
            {
                cb_quality.SelectedItem = startOption;
                SelectedVideoOption = startOption;
            }

            // FPS
            if (cb_quality.Items.Count > 0 && startOption.Fps != null)
            {
                cb_fps.Items.Clear();
                cb_fps.Items.AddRange([startOption.Fps]);
                cb_fps.SelectedIndex = 0;
            } 

            // Download Mode
            var modes = new ComboboxItem<DownloadMode>[]
            {
            new() {Text = "Video & Audio", Value = DownloadMode.VideoWithAudio},
            new() {Text = "Video", Value = DownloadMode.VideoOnly},
            new() {Text = "Audio", Value = DownloadMode.AudioOnly}
            };
            cb_mode.Items.Clear();
            cb_mode.Items.AddRange(modes);
            cb_mode.SelectedIndex = 0;
            cb_mode.DisplayMember = "Text";
            cb_mode.ValueMember = "Value";
        }

        private async void btnDownload_Click(object sender, EventArgs e)
        {
            btn_download.Enabled = false;
            btn_download.Text = "Loading...";
            pb_progress.Value = 0;

            var mode = cb_mode.SelectedItem as ComboboxItem<DownloadMode>;

            if (DownloadClicked != null && 
                SelectedVideoOption != null &&
                mode != null)
            {
                var request = new DownloadRequest
                {
                    Video = Video,
                    Option = SelectedVideoOption,
                    Mode = mode.Value
                };

                var startTime = DateTime.Now;
                SetOutputText($"----- Start: {startTime}");

                await DownloadClicked(this, request);

                var endTime = DateTime.Now;
                SetOutputText($"----- End: {endTime}");
                SetOutputText($"----- Duration: {endTime - startTime}");
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
            if (option.Fps != null)
            {
                cb_fps.Items.AddRange([option.Fps]);
                cb_fps.SelectedIndex = 0;
                cb_fps.Enabled = true;
            } 
            else
            {
                cb_fps.Enabled = false;
            }

            lbl_estimatedSizeValue.Text = option.EstimatedSize.HasValue ? $"~{FilesizeParser.ReadableFileSize(option.EstimatedSize.Value)}" : "N/A";
        }

        private void btn_openLog_Click(object sender, EventArgs e)
        {
            ShowLogWindow();
        }

        // Updates internal values like ETA or progressbar
        public void UpdateProgress(string data)
        {
            SetETA(data);
            SetProgress(data);
            SetOutputText(data);
        }

        private void SetETA(string data)
        {
            Regex regex = new Regex("ETA *\\d{2}:\\d{2}");
            Match match = regex.Match(data);
            if (match.Success)
            {
                tb_ETA.Text = match.Value;
            }
        }

        private void SetProgress(string data)
        {
            var match = Regex.Match(data, @"\b(\d{1,3})\.*\d*%");  // Searches for "XXX.X%"
            if (match.Success)
            {
                if (int.TryParse(match.Groups[1].Value, out int percent))
                {
                    pb_progress.Value = percent;
                }
            }
        }

        private void SetOutputText(string data)
        {
            logBuffer.Add(data);
            AppendLogToLogFile(data);

            if (logWindow != null && !logWindow.IsDisposed)
            {
                logWindow?.Append(data);
            }
        }

        private void ShowLogWindow()
        {
            if (logWindow == null || logWindow.IsDisposed)
                logWindow = new LogForm(Video.Title);

            foreach (var line in logBuffer)
            {
                logWindow.Append(line);
            }

            logWindow.Show();
            logWindow.BringToFront();
        }

        private void AppendLogToLogFile(string data)
        {
            if (!Constants.Settings.AutoSaveLog) return;

            var filename = Constants.LOG_FILENAME_TEMPLATE.Replace("#Title#", Title);
            var filePath = Path.Combine(Constants.Settings.LogSaveDirectory, filename);

            File.AppendAllLines(filePath, [data]);
        }
    }
}
