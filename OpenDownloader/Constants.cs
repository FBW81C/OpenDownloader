using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenDownloader.model.Settings;

namespace OpenDownloader;
public static class Constants
{
    // Application Constants
    public readonly static string APPLICATION_NAME = "OpenDownloader";
    public readonly static string APPLICATION_FOLDER_NAME = $"{APPLICATION_NAME}_FBW81C";
    public readonly static string FILEENDING = "odp";

    // User data paths
    public readonly static string SETTINGS_PATH = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        APPLICATION_FOLDER_NAME
    );
    public readonly static string SETTINGS_FILE_PATH = Path.Combine(SETTINGS_PATH, "settings.json");
    public readonly static string HISTORY_PATH = Path.Combine(SETTINGS_PATH, "history.txt");

    // Application data paths
    public readonly static string APPLICATION_PATH = AppDomain.CurrentDomain.BaseDirectory;
    public readonly static string ASSETS_PATH = Path.Combine(APPLICATION_PATH, "assets");
    public readonly static string DEPENDENCIES_PATH = Path.Combine(ASSETS_PATH, "dependencies");
    public readonly static string TEXTS_PATH = Path.Combine(ASSETS_PATH, "texts");

    // Dependency paths
    public readonly static string ytdlpPath = Path.Combine(DEPENDENCIES_PATH, "yt-dlp.exe");
    public readonly static string ffmpegPath = Path.Combine(DEPENDENCIES_PATH, "ffmpeg.exe");

    // Global variables during runtime
    public static Settings Settings { get; set; }
    public static Dictionary<string, string> History { get; set; }

    // Links
    public readonly static string LINK_GITHUB = $"https://github.com/FBW81C/{APPLICATION_NAME}";
    public readonly static string LINK_GITHUB_LATEST = $"https://api.github.com/repos/FBW81C/{APPLICATION_NAME}/releases/latest";

    // Other
    public readonly static string LOG_FILENAME_TEMPLATE = "log_#Title#.txt";
    public readonly static string VERSION_TEMPLATE = "#VERSION#";
}