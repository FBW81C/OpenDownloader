using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDownloader.model
{
    public class Video
    {
        public string Title { get; set; }
        public string WebpageUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public Image Thumbnail { get; set; }

        public List<VideoOption> Options { get; set; } = new();
    }
}
