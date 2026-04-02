using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDownloader.model;
public class Settings
{
    public string DefaultSaveDirectory { get; set; } = string.Empty;
    public bool ShowNotifications { get; set; } = true;
    public int NotificationDurationMs { get; set; } = 3000;
    public bool AutoSaveLog { get; set; } = false;
    public string LogSaveDirectory { get; set; } = string.Empty;
}
