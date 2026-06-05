using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OpenDownloader.lib;

public static class JsonParser
{
    public static int? GetInt32Flexible(JsonElement parent, string name)
    {
        if (!parent.TryGetProperty(name, out var prop))
            return null;

        return prop.ValueKind switch
        {
            JsonValueKind.Number => prop.GetInt32(),
            JsonValueKind.String when int.TryParse(prop.GetString(), out var val) => val,
            _ => null
        };
    }
    public static Int64? GetInt64Flexible(JsonElement parent, string name)
    {
        if (!parent.TryGetProperty(name, out var prop))
            return null;

        return prop.ValueKind switch
        {
            JsonValueKind.Number => prop.GetInt64(),
            JsonValueKind.String when Int64.TryParse(prop.GetString(), out var val) => val,
            _ => null
        };
    }
}
