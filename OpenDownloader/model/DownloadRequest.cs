using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDownloader.model;
public class DownloadRequest
{
    public Video Video { get; init; }
    public VideoOption Option { get; init; }
    public DownloadMode Mode { get; init; }
}