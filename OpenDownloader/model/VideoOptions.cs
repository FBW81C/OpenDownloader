using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDownloader.model
{
    public class VideoOption
    {
        public VideoOptionType Type { get; set; } = VideoOptionType.SpecificFormat;

        public int? Width { get; set; }
        public int? Height { get; set; }
        public double? Fps { get; set; }

        public long? EstimatedSize { get; set; }
        public string? FormatId { get; set; }
        public string? AdditionalInfo { get; set; }

        public string Resolution
        {
            get
            {
                return Type switch
                {
                    VideoOptionType.Best => "Best quality",
                    VideoOptionType.Worst => "Worst quality",
                    _ => $"{Width}x{Height} {(AdditionalInfo != null ? $"({AdditionalInfo})" : "")}"
                };
            }
        }
    }
}
