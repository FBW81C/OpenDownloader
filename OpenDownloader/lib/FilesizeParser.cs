using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDownloader.lib
{
    public static class FilesizeParser
    {
        public static string GetTextForm(long size)
        {
            string text = "";
            int operations = 0;

            // 1'000'000'000 B = 1'000'000 KB = 1'000 MB = 1 GB
            // 1'000'000 B = 1'000 KB = 1 MB
            // 1'000 B = 1 KB

            while (size > 999 && operations < 5) 
            {
                size /= 1000;
                operations++;
            }
            text = size.ToString();
            switch (operations)
            {
                case 0:
                    text += " B";
                    break;
                case 1:
                    text += " KB";
                    break;
                case 2:
                    text += " MB";
                    break;
                case 3:
                    text += " GB";
                    break;
                case 4:
                    text += " TB";
                    break;
            }
            return text;
        }
    }
}
