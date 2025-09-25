using NuGetTrends.Portal.Models;

namespace NuGetTrends.Portal.Services;

public interface INugetTrendsWebService
{
    public Task<ICollection<PackageSearchResult>> SearchPackagesAsync(string query,
        CancellationToken cancellationToken = default);

    public Task<HistoryResult> GetDownloadHistoryAsync(string packageId, int? months,
        CancellationToken cancellationToken = default);
}
