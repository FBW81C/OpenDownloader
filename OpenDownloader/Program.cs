using OpenDownloader.model;

namespace OpenDownloader
{
    internal static class Program
    {
        public static ProgrammForm programForm;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            EnsureIntegrity();

            CreateSettingsFolderIfNotExist();

            // TODO: Check for yt-dlp and ffmpeg updates

            programForm = new ProgrammForm();
            Application.Run(programForm);
        }

        public static void CreateSettingsFolderIfNotExist()
        {
            if (!Directory.Exists(Constants.SETTINGS_PATH))
            {
                Directory.CreateDirectory(Constants.SETTINGS_PATH);
            }
        }
        public static void EnsureIntegrity()
        {
            if (!File.Exists(Constants.ytdlpPath))
            {
                MessageBox.Show("yt-dlp.exe not found!\nReinstall OpenDownloader to fix issue or copy yt-dlp.exe to assets folder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
            if (!File.Exists(Constants.ffmpegPath))
            {
                MessageBox.Show("ffmpeg.exe not found!\nyt-dlp.exe will run with limited functionality.\nReinstall OpenDownloader to fix issue or copy ffmpeg.exe to assets folder.", $"Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}