using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using OpenDownloader.lib;
using OpenDownloader.model;

namespace OpenDownloader.ytdlpUtil
{
    internal static class Service
    {
        public static async Task<bool> DownloadFileWithProgressAsync(string url, string folder, Dictionary<string, string> arguments, IProgress<int> progress)
        {
            string? quality = (arguments["quality"] == "Best" ? null : $"[height={arguments["quality"].Split("x")[^1]}]");
            string? fps = (arguments["fps"] == "Best" ? null : $"[fps={arguments["fps"]}]"); 

            var args = $"-P \"{folder.Replace("\\", "/")}\" -f \"bestvideo{quality??""}{fps??""}+bestaudio\" \"{url}\"";
            return await ytdlpExecution.DownloadFileAsync(args, progress);
        }
    }
}
