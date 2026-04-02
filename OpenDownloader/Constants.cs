using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDownloader;
public static class Constants
{
    public readonly static string APPLICATION_NAME = "OpenDownloader";
    public readonly static string APPLICATION_FOLDER_NAME = $"{APPLICATION_NAME}_FBW81C";
    public readonly static string FILEENDING = "odp";

    public readonly static string APPLICATION_PATH = AppDomain.CurrentDomain.BaseDirectory;
    public readonly static string ASSETS_PATH = Path.Combine(APPLICATION_PATH, "assets");
    public readonly static string DEPENDENCIES_PATH = Path.Combine(ASSETS_PATH, "dependencies");
    public readonly static string TEXTS_PATH = Path.Combine(ASSETS_PATH, "texts");

    public readonly static string ytdlpPath = Path.Combine(DEPENDENCIES_PATH, "yt-dlp.exe");
    public readonly static string ffmpegPath = Path.Combine(DEPENDENCIES_PATH, "ffmpeg.exe");

    public readonly static string SETTINGS_PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), APPLICATION_FOLDER_NAME);
    public readonly static string defaultDirectoryPathFileName = "defaultDir.sys";

    public readonly static string LINK_GITHUB = $"https://github.com/FBW81C/{APPLICATION_NAME}";
}