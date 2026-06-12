using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using OpenDownloader.model.Update;

namespace OpenDownloader.lib;
public static class Updater
{
    public static async Task<UpdateResult> CheckForUpdateAsync()
    {
        // Loading current version from assembly
        var informationalVersion = Assembly
                .GetExecutingAssembly()
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                ?.InformationalVersion;

        if (string.IsNullOrWhiteSpace(informationalVersion))
            throw new InvalidOperationException("AssemblyInformationalVersion is missing.");

        if (!Version.TryParse(informationalVersion, out var currentVersion))
            throw new FormatException($"Invalid assembly version: '{informationalVersion}'.");

        // Fetch latest version from github
        using var request = new HttpRequestMessage(HttpMethod.Get, Constants.LINK_GITHUB_LATEST);
        request.Headers.UserAgent.ParseAdd("OpenDownloader");

        using var client = new HttpClient();
        using var response = await client.SendAsync(request);

        if (!response.IsSuccessStatusCode)
            throw new HttpRequestException(
                $"GitHub request failed with status code {(int)response.StatusCode} ({response.ReasonPhrase}).");

        var json = await response.Content.ReadAsStringAsync();

        using var doc = JsonDocument.Parse(json);

        if (!doc.RootElement.TryGetProperty("tag_name", out var tagElement))
            throw new KeyNotFoundException("Property 'tag_name' not found in GitHub response.");

        var latestTagRaw = tagElement.GetString();

        if (string.IsNullOrWhiteSpace(latestTagRaw))
            throw new InvalidOperationException("GitHub tag_name is null or empty.");

        var normalizedTag = latestTagRaw.TrimStart('v', 'V');

        if (!Version.TryParse(normalizedTag, out var latestVersion))
            throw new FormatException($"Invalid GitHub version format: '{latestTagRaw}'.");

        return new UpdateResult(
            latestVersion > currentVersion,
            currentVersion,
            latestVersion);
    }
}
