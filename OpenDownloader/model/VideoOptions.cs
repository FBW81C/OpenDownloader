using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDownloader.model
{
    public class VideoOption
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Fps { get; set; }
        public long? EstimatedSize { get; set; }
        public string FormatId { get; set; }
        public string Resolution => $"{Width}x{Height}";
    }
}
