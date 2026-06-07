using OpenDownloader.lib;
using OpenDownloader.model;
using System.Text.RegularExpressions;

namespace OpenDownloader
{
    public partial class DownloadItem : UserControl
    {
        private Video Video;
        private VideoOption SelectedVideoOption;

        // Video Options
        private List<VideoOption> NormalVideoOptions = [];
        private List<VideoOption> AdvancedVideoOptions = [];
        private List<VideoOption> AudioOptions = [];

        // Log
        private LogForm logWindow;
        List<string> logBuffer = new();

        // Actions
        public event Func<object?, DownloadRequest, Task>? DownloadClicked;
        public event EventHandler? DeleteClicked;

        // Internal State Management
        private bool _isInitializing = true;

        public DownloadItem(Video video)
        {
            InitializeComponent();

            Video = video;

            pb_thumbnail.Image = video.Thumbnail;
            lbl_title.Text = video.Title;

            // Download Mode
            var modes = new ComboboxItem<DownloadMode>[]
                {
                    new() {Text = "Video & Audio", Value = DownloadMode.VideoWithAudio},
                    new() {Text = "Video", Value = DownloadMode.VideoOnly},
                    new() {Text = "Audio", Value = DownloadMode.AudioOnly}
                };
            cb_mode.DataSource = modes;
            cb_mode.DisplayMember = "Text";
            cb_mode.SelectedIndex = 0;

            // Video Formats
            NormalVideoOptions = GetNormalVideoOptions(video.Options);
            AdvancedVideoOptions = video.Options;
            AudioOptions = video.AudioOptions;

            _isInitializing = false;

            SetQualityComboboxContent();
        }

        private List<VideoOption> GetNormalVideoOptions(List<VideoOption> options)
        {
            var grouped = options
               .Where(f => f.Type == VideoOptionType.SpecificFormat)
               .GroupBy(f => new
               {
                   f.Height,
                   f.Fps
               });
            var virtualOptions = options
                .Where(f => f.Type != VideoOptionType.SpecificFormat)
                .ToList();

            VideoOption PickBest(IGrouping<object, VideoOption> group)
            {
                return group
                    .OrderByDescending(f => f.VideoExt == "mp4")
                    .ThenByDescending(f => f.VCodec != null && f.VCodec.StartsWith("avc1"))
                    .ThenByDescending(f => f.Filesize ?? 0)
                    .First();
            }

            var normalOptions = grouped
                .Select(PickBest)
                .OrderByDescending(f => f.Height ?? 0)
                .ThenByDescending(f => f.Fps ?? 0)
                .ToList();

            // Best
            var best = virtualOptions.FirstOrDefault(f => f.Type == VideoOptionType.Best);
            if (best != null)
                normalOptions.Insert(0, best);

            // Worst
            var worst = virtualOptions.FirstOrDefault(f => f.Type == VideoOptionType.Worst);
            if (worst != null)
                normalOptions.Add(worst);

            return normalOptions;
        }

        private void SetQualityComboboxContent()
        {
            var mode = cb_mode.SelectedItem as ComboboxItem<DownloadMode>;

            if (mode == null)
            {
                throw new Exception("Code should not get here");
            }

            ComboboxItem<VideoOption>[] items;

            if (mode.Value == DownloadMode.VideoWithAudio || mode.Value == DownloadMode.VideoOnly) // Video & Video With Audio Streams
            {
                items = (Constants.Settings.ShowAdvancedVideoInfo ? AdvancedVideoOptions : NormalVideoOptions)
                    .Select(option => new ComboboxItem<VideoOption>
                    {
                        Value = option,
                        Text = Constants.Settings.ShowAdvancedVideoInfo ? option.GetAdvancedVideoDisplay() : option.GetNormalVideoDisplay()
                    })
                    .ToArray();
            }
            else // Auido Streams
            {
                items = AudioOptions.Select(option => new ComboboxItem<VideoOption>
                {
                    Value = option,
                    Text = Constants.Settings.ShowAdvancedVideoInfo ? option.GetAdvancedAudioDisplay() : option.GetNormalAudioDisplay()
                })
                .ToArray();
            }

            cb_quality.DataSource = items;
            cb_quality.DisplayMember = "Text";
        }

        //public void UpdateDisplay(bool advanced)
        //{
        //    foreach (ComboboxItem<VideoOption> item in cb_quality.Items)
        //    {
        //        item.Text = advanced
        //            ? GetAdvancedDisplay(item.Value)
        //            : GetNormalDisplay(item.Value);
        //    }

        //    cb_quality.Refresh();
        //}

        private async void btnDownload_Click(object sender, EventArgs e)
        {
            btn_download.Enabled = false;
            btn_delete.Enabled = false;
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
            btn_delete.Enabled = true;
        }

        private void cb_quality_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_isInitializing) return;

            var comboxBoxItem = cb_quality.SelectedItem as ComboboxItem<VideoOption>;
            var option = comboxBoxItem?.Value;

            if (option == null)
            {
                throw new ArgumentException("Could should not get here");
            }

            SelectedVideoOption = option;

            lbl_estimatedSizeValue.Text = option.Filesize.HasValue ? $"~{FilesizeParser.ReadableFileSize(option.Filesize.Value)}" : "N/A";
        }

        private void cb_mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isInitializing) return;

            SetQualityComboboxContent();
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
            {
                logWindow = new LogForm(Video.Title);

                foreach (var line in logBuffer)
                {
                    logWindow.Append(line);
                }
            }


            logWindow.Show();
            logWindow.BringToFront();
        }

        private void AppendLogToLogFile(string data)
        {
            if (!Constants.Settings.AutoSaveLog) return;

            var filename = Constants.LOG_FILENAME_TEMPLATE.Replace("#Title#", Video.Title);
            var filePath = Path.Combine(Constants.Settings.LogSaveDirectory, filename);

            File.AppendAllLines(filePath, [data]);
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DeleteClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
