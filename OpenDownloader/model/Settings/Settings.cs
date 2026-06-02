using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDownloader.model.Settings;
public class Settings
{
    // Downloading
    public string DefaultSaveDirectory { get; set; } = string.Empty;
    // Notifications
    public bool ShowNotifications { get; set; } = true;
    public int NotificationDurationSec { get; set; } = 3;
    // Logging
    public bool AutoSaveLog { get; set; } = false;
    public string LogSaveDirectory { get; set; } = string.Empty;
    // After Download
    public AfterDownloadOptions AfterDownload { get; set; } = AfterDownloadOptions.NaviagteOnNotificationClick;
    // DownoadItem
    public bool ShowAdvancedVideoInfo { get; set; } = false;

    public Settings Clone()
    {
        return new Settings
        {
            DefaultSaveDirectory = DefaultSaveDirectory,
            ShowNotifications = ShowNotifications,
            NotificationDurationSec = NotificationDurationSec,
            AutoSaveLog = AutoSaveLog,
            LogSaveDirectory = LogSaveDirectory,
            AfterDownload = AfterDownload,
            ShowAdvancedVideoInfo = ShowAdvancedVideoInfo
        };
    }
}


