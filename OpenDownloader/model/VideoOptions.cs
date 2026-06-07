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
        // General
        public string? Id { get; set; }
        public long? Filesize { get; set; }
        public string? FormatNote { get; set; }
        // Video
        public int? Width { get; set; }
        public int? Height { get; set; }
        public double? Fps { get; set; }
        public string? VideoExt { get; set; }
        public string? VCodec { get; set; }
        // Audio
        public string? AudioExt { get; set; }
        public string? ACodec { get; set; }
        public double? Abr { get; set; }
        public double? Asr { get; set; }
        public int? AudioChannels { get; set; }

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

        public string GetNormalVideoDisplay()
        {
            if (Type != VideoOptionType.SpecificFormat)
            {
                return Resolution;
            }

            if (VCodec == "none")
                return $"Audio only ({VideoExt})";

            string res = Resolution ?? "Unknown";
            string fps = Fps.HasValue ? $" @ {Fps:0}fps" : "";
            string note = !string.IsNullOrEmpty(FormatNote) ? $" ({FormatNote})" : "";

            return $"{res}{fps}{note}";
        }

        public string GetAdvancedVideoDisplay()
        {
            if (Type != VideoOptionType.SpecificFormat)
            {
                return Resolution;
            }

            string res = VCodec == "none"
                ? "audio"
                : Resolution ?? "Unknown";

            string fps = Fps.HasValue ? $"@{Fps:0}" : "";
            string note = !string.IsNullOrEmpty(FormatNote) ? $" ({FormatNote})" : "";

            return $"{Id} - {res}{fps} - {VideoExt} - {VCodec}{note}";
        }

        public string GetNormalAudioDisplay()
        {
            if (Type != VideoOptionType.SpecificFormat)
            {
                return Resolution;
            }

            var codec = ACodec ?? "unknown";
            var abr = Abr != null ? $"{Math.Round((double)Abr)} kbps" : GetQualityLabel(Abr);

            return $"{AudioExt} - {codec} ({abr})";
        }

        public string GetAdvancedAudioDisplay()
        {
            if (Type != VideoOptionType.SpecificFormat)
            {
                return Resolution;
            }

            var id = Id ?? "?";
            var codec = ACodec ?? "unknown";
            var abr = Abr != null ? $"{Math.Round((double)Abr)} kbps" : "unknown";
            var asr = Asr != null ? $"{Asr / 1000} kHz" : "?";
            var ch = AudioChannels.ToString() ?? "?";
            var ext = AudioExt ?? "?";

            return $"{id} - {codec} ({abr}, {asr}, {ch}ch) - {ext}";
        }

        private static string GetQualityLabel(double? abr)
        {
            if (abr == null) return "unknown";

            if (abr < 64) return "low";
            if (abr < 128) return "medium";
            return "high";
        }
    }
}
