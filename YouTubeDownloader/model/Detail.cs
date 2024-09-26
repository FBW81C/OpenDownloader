using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeDownloader.model
{
    public class Detail
    {
        public Quality Quality {  get; set; }
        public List<int> FPS { get; set; } = [];
        public FileSize Size { get; set; }
    }
}
