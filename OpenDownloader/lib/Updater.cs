using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OpenDownloader.lib;
public static class Updater
{
    public static async Task CheckForUpdateAsync()
    {
        var informationalVersion = Assembly
                .GetExecutingAssembly()
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                ?.InformationalVersion;
        if (informationalVersion == null) return;

        var currentVersion = new Version(informationalVersion);

        using var client = new HttpClient();
        client.DefaultRequestHeaders.UserAgent.ParseAdd("OpenDownloader");

        var json = await client.GetStringAsync(Constants.LINK_GITHUB_LATEST);

        using var doc = JsonDocument.Parse(json);
        var latestTag = doc.RootElement.GetProperty("tag_name").GetString();

        if (latestTag == null) return;

        // "v2.4" → "2.4"
        latestTag = latestTag.TrimStart('v');

        var latestVersion = new Version(latestTag);

        if (latestVersion > currentVersion)
        {
            MessageBox.Show(
                $"New version available: {latestVersion}\nCurrent version: {currentVersion}",
                "OpenDownloader Updater",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}
