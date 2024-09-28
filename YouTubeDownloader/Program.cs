using YouTubeDownloader.model;

namespace YouTubeDownloader
{
    internal static class Program
    {
        public static readonly string programFolderName = "YouTubeDownloaderFBW81C";
        public static readonly string programFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), programFolderName);
        public static readonly string ytdlpPath = Path.Combine(programFolderPath, "yt-dlp.exe");
        public static readonly string defaultDirectoryPathFileName = "defaultDir.sys";

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
            programForm = new ProgrammForm();
            if (Directory.Exists(programFolderPath) && File.Exists(Path.Combine(programFolderPath, "yt-dlp.exe")))
            {
                Application.Run(programForm);
            } 
            else
            {
                InstallForm installForm = new();
                if (installForm.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(programForm);
                }
            }

        }
    }
}