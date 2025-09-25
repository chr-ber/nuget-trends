using System.Net.Http.Json;
using System.Text.Json;
using NuGetTrends.Portal.Models;

namespace NuGetTrends.Portal.Services;

public class NugetTrendsWebService(HttpClient httpClient) : INugetTrendsWebService
{
    private static readonly JsonSerializerOptions? JsonOptions = new() { PropertyNameCaseInsensitive = true };

    public async Task<ICollection<PackageSearchResult>> SearchPackagesAsync(string query, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.GetAsync($"/api/packages/search?q={Uri.EscapeDataString(query)}", cancellationToken);
        response.EnsureSuccessStatusCode();

        var jsonString = await response.Content.ReadAsStringAsync(cancellationToken);
        return JsonSerializer.Deserialize<ICollection<PackageSearchResult>>(jsonString,JsonOptions)
               ?? (List<PackageSearchResult>) [];
    }

    public async Task<HistoryResult> GetDownloadHistoryAsync(string packageId, int? months,  CancellationToken cancellationToken = default)
    {
        var response = await httpClient.GetAsync($"/api/package/history/{packageId}?months={months}", cancellationToken);
        response.EnsureSuccessStatusCode();

        var jsonString = await response.Content.ReadAsStringAsync(cancellationToken);
        return JsonSerializer.Deserialize<HistoryResult>(jsonString, JsonOptions) ?? new HistoryResult(packageId, []);
    }

    public async Task<HistoryResult?> GetDownloadHistoryAltAsync(string packageId, int? months,  CancellationToken cancellationToken = default)
    {
        return await httpClient.GetFromJsonAsync<HistoryResult>(
            $"/api/package/history/{packageId}?months={months}",
            cancellationToken);
    }
}
