using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDownloader.model.Update;
public record UpdateResult(bool UpdateFound, Version CurrentVersion, Version LatestVersion)
{
}
