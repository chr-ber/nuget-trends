namespace NuGetTrends.Portal.Models;

public record PackageSearchResult(string PackageId, long? LatestDownloadCount, string IconUrl);
