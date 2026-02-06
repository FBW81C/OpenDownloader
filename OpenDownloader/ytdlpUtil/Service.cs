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
        public static async Task<List<Detail>> GetFileInfoAsync(string url)
        {
            var list =  await ytdlpExecution.DownloadFileInfoAsync(url);

            /*var strings = new List<string[]>();

            foreach (var item in list)
            {
                strings.Add(item.Split("x"));
            }

            for (var i = 0; i < strings.Count; i++)
            {
                var currentitem = strings[i];
                for ( var j = i+1; j < strings.Count; j++)
                {
                    var itemtocompare = strings[j];
                    if (Int32.Parse(currentitem[0]) >= Int32.Parse(itemtocompare[0]))
                    {
                        strings[i] = itemtocompare;
                        strings[j] = currentitem;
                    }
                }
            }
            strings.Reverse();

            var sortedlist = new List<string>();
            for (var i = 0;i < strings.Count; i++)
            {
                sortedlist.Add($"{strings[i][0]}x{strings[i][1]}");
            }*/

            //list.Add("worst");
            return list;
        }
    }
}
