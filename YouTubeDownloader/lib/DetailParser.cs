using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using YouTubeDownloader.model;

namespace YouTubeDownloader.lib
{
    public static class DetailParser
    {
        public static List<Detail> ParseToDetail(List<string> lines)
        {
            var details = new Dictionary<string, Detail>();
            var resolutionAmounts = new Dictionary<string, int>();

            foreach (var line in lines)
            {
                // Extract Quality and FPS
                var parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var resolution = parts[0]; // Format: WidthxHeight
                var fps = int.Parse(parts[1]); // FPS

                // Extract File size 
                var sizePart = parts.Last(part => part.Contains("KiB") || part.Contains("MiB") || part.Contains("GiB") || part.Contains("TiB"));
                var sizeInBytes = ConvertSizeToBytes(sizePart);

                // split quality
                var resolutionParts = resolution.Split('x');
                var width = int.Parse(resolutionParts[0]);
                var height = int.Parse(resolutionParts[1]);

                // create detail or add things to existing detail
                var resolutionKey = $"{width}x{height}";


                resolutionAmounts.TryAdd(resolutionKey, !resolutionAmounts.ContainsKey(resolutionKey) ? 1 : resolutionAmounts[resolutionKey]++); // Increments value or adds it
                if (!details.ContainsKey(resolutionKey))
                {
                    details[resolutionKey] = new Detail
                    {
                        Quality = new Quality { Width = width, Height = height },
                        FPS = new List<int>(),
                        Size = 0
                    };
                }

                // Add fps if not already added
                if (!details[resolutionKey].FPS.Contains(fps))
                {
                    details[resolutionKey].FPS.Add(fps);
                }

                // add filesize
                details[resolutionKey].Size += sizeInBytes;
            }

            foreach (var detail in details.Values)
            {
                detail.Size /= resolutionAmounts[detail.Quality.ToString()]; // Average filesize
            }

            return details.Values.ToList();
        }

        private static long ConvertSizeToBytes(string sizePart)
        {
            Regex regex = new Regex(@"\d+\.\d+|\d+");
            var match = regex.Match(sizePart);

            var sizeValue = (long)Convert.ToDouble(match.Success ? match.Groups[0].Value : "0");
            var unit = sizePart.Substring(sizePart.Length - 3);

            switch (unit)
            {
                case "KiB":
                    return (long)(sizeValue * 1024);
                case "MiB":
                    return (long)(sizeValue * 1024 * 1024);
                case "GiB":
                    return (long)(sizeValue * 1024 * 1024 * 1024);
                case "TiB":
                    return (long)(sizeValue * 1024 * 1024 * 1024 * 1024);
                default:
                    throw new InvalidOperationException($"Unknown unit: {unit}");
            }
        }
    }
}
