namespace YouTubeDownloader
{
    internal static class Program
    {
        public static readonly string programFolderName = "YouTubeDownloaderFBW81C";
        public static readonly string programFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), programFolderName);
        public static readonly string defaultDirectoryPathFileName = "defaultDir.sys";
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            if (Directory.Exists(programFolderPath) && File.Exists(Path.Combine(programFolderPath, "yt-dlp.exe")))
            {
                Application.Run(new ProgrammForm());
            } 
            else
            {
                InstallForm installForm = new();
                if (installForm.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new ProgrammForm());
                }
            }

        }
    }
}