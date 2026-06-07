using System.Text.Json;
using OpenDownloader.model.Settings;

namespace OpenDownloader
{
    internal static class Program
    {
        public static ProgrammForm programForm;

        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font, see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            EnsureIntegrity();
            CreateSettingsFolder();
            LoadSettings();
            LoadHistory();

            // TODO: Check for yt-dlp and ffmpeg updates

            programForm = new ProgrammForm();
            Application.Run(programForm);
        }

        public static void LoadSettings()
        {
            try
            {
                if (File.Exists(Constants.SETTINGS_FILE_PATH))
                {
                    var json = File.ReadAllText(Constants.SETTINGS_FILE_PATH);
                    var settings = JsonSerializer.Deserialize<Settings>(json);

                    if (settings != null)
                    {
                        Constants.Settings = settings;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Settings could not be loaded from \"{Constants.SETTINGS_FILE_PATH}\"\nLoading default settings\n\nReason:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Constants.Settings = new Settings();
        }
        public static void LoadHistory()
        {
            try
            {
                if (File.Exists(Constants.HISTORY_PATH))
                {
                    var history = new Dictionary<string, string>();

                    foreach (var line in File.ReadLines(Constants.HISTORY_PATH))
                    {
                        var parts = line.Split('\t', 2);

                        var url = parts[0];
                        var title = parts.Length > 1 ? parts[1] : "";

                        history[url] = title;
                    }

                    Constants.History = history;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"History could not be loaded from \"{Constants.HISTORY_PATH}\"\nLoading empty history\n\nReason:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Constants.History = [];
        }

        public static void EnsureIntegrity()
        {
            if (!File.Exists(Constants.ytdlpPath))
            {
                MessageBox.Show($"yt-dlp.exe not found!\nReinstall OpenDownloader to fix issue or copy yt-dlp.exe to \"{Constants.ytdlpPath}\"", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
            if (!File.Exists(Constants.ffmpegPath))
            {
                MessageBox.Show($"ffmpeg.exe not found!\nyt-dlp.exe will run with limited functionality.\nReinstall OpenDownloader to fix issue or copy ffmpeg.exe to \"{Constants.ffmpegPath}\"", $"Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public static void CreateSettingsFolder()
        {
            if (!Directory.Exists(Constants.SETTINGS_PATH))
            {
                Directory.CreateDirectory(Constants.SETTINGS_PATH);
            }
        }
    }
}