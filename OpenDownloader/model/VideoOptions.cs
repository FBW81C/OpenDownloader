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

        public string? Id { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public double? Fps { get; set; }
        public long? Filesize { get; set; }
        public string? VideoExt { get; set; }
        public string? AudioExt { get; set; }
        public string? VCodec { get; set; }
        public string? ACodec { get; set; }
        public string? FormatNote { get; set; }

        public string Resolution
        {
            get
            {
                return Type switch
                {
                    VideoOptionType.Best => "Best quality",
                    VideoOptionType.Worst => "Worst quality",
                    _ => $"{Width}x{Height}"
                };
            }
        }
    }
}
