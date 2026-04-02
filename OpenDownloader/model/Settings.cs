using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDownloader.model;
public class Settings
{
    // Downloading
    public string DefaultSaveDirectory { get; set; } = string.Empty;
    // Notifications
    public bool ShowNotifications { get; set; } = true;
    public int NotificationDurationMs { get; set; } = 3000;
    // Logging
    public bool AutoSaveLog { get; set; } = false;
    public string LogSaveDirectory { get; set; } = string.Empty;
}
