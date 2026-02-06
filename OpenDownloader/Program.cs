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

            CreateSettingsFolderIfNotExist();

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
    }
}