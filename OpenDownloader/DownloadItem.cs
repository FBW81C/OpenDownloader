using OpenDownloader.lib;
using OpenDownloader.model;
using System.Text.RegularExpressions;
using static System.Windows.Forms.DataFormats;

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
        public event EventHandler? DeleteClicked;

        public DownloadItem(Video video)
        {
            InitializeComponent();

            Video = video;

            pb_thumbnail.Image = video.Thumbnail;
            lbl_title.Text = video.Title;

            // Formats
            var grouped = video.Options
                .Where(f => f.Type == VideoOptionType.SpecificFormat)
                .GroupBy(f => new
                {
                    f.Height,
                    f.Fps
                });
            var virtualOptions = video.Options
                .Where(f => f.Type != VideoOptionType.SpecificFormat)
                .ToList();

            VideoOption PickBest(IGrouping<object, VideoOption> group)
            {
                return group
                    .OrderByDescending(f => f.Ext == "mp4")
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

            List<VideoOption> advancedOptions = video.Options;

            cb_quality.Items.Clear();
            var formats = 
                (Constants.Settings.ShowAdvancedVideoInfo ? advancedOptions : normalOptions)
                .Select(option => new ComboboxItem<VideoOption> 
                    { 
                        Value = option, 
                        Text = Constants.Settings.ShowAdvancedVideoInfo ? GetAdvancedDisplay(option) : GetNormalDisplay(option)
                    })
                .ToArray();
            cb_quality.DataSource = formats;
            cb_quality.DisplayMember = "Text";

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

        private string GetNormalDisplay(VideoOption option)
        {
            if (option.Type != VideoOptionType.SpecificFormat)
            {
                return option.Resolution;
            }

            if (option.VCodec == "none")
                return $"Audio only ({option.Ext})";

            string res = option.Resolution ?? "Unknown";
            string fps = option.Fps.HasValue ? $" @ {option.Fps:0}fps" : "";
            string note = !string.IsNullOrEmpty(option.FormatNote) ? $" ({option.FormatNote})" : "";

            return $"{res}{fps}{note}";
        }

        private string GetAdvancedDisplay(VideoOption option)
        {
            if (option.Type != VideoOptionType.SpecificFormat)
            {
                return option.Resolution;
            }

            string res = option.VCodec == "none"
                ? "audio"
                : option.Resolution ?? "Unknown";

            string fps = option.Fps.HasValue ? $"@{option.Fps:0}" : "";
            string note = !string.IsNullOrEmpty(option.FormatNote) ? $" ({option.FormatNote})" : "";

            return $"{option.Id} - {res}{fps} - {option.Ext} - {option.VCodec}{note}";
        }

        public void UpdateDisplay(bool advanced)
        {
            foreach (ComboboxItem<VideoOption> item in cb_quality.Items)
            {
                item.Text = advanced
                    ? GetAdvancedDisplay(item.Value)
                    : GetNormalDisplay(item.Value);
            }

            cb_quality.Refresh();
        }

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
            var comboxBoxItem = cb_quality.SelectedItem as ComboboxItem<VideoOption>;
            var option = comboxBoxItem?.Value;

            if (option == null)
            {
                throw new ArgumentException("Could should not get here");
            }

            SelectedVideoOption = option;

            lbl_estimatedSizeValue.Text = option.Filesize.HasValue ? $"~{FilesizeParser.ReadableFileSize(option.Filesize.Value)}" : "N/A";
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

            var filename = Constants.LOG_FILENAME_TEMPLATE.Replace("#Title#", Title);
            var filePath = Path.Combine(Constants.Settings.LogSaveDirectory, filename);

            File.AppendAllLines(filePath, [data]);
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DeleteClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
