using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDownloader;
public static class Constants
{
    public readonly static string APPLICATION_FOLDER_NAME = "OpenDownloader_FBW81C";
    public readonly static string FILEENDING = "odp";

    public readonly static string APPLICATION_PATH = AppDomain.CurrentDomain.BaseDirectory;
    public readonly static string defaultDirectoryPathFileName = "defaultDir.sys";
    public readonly static string ytdlpPath = Path.Combine(APPLICATION_PATH, "assets", "yt-dlp.exe");

    public readonly static string SETTINGS_PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), APPLICATION_FOLDER_NAME, "settings");

    public readonly static string LINK_GITHUB = "https://github.com/FBW81C/OpenDownloader";

    public static string lastUrl = "";

}