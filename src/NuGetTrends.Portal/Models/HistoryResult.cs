namespace NuGetTrends.Portal.Models;

public record HistoryResult(string Id, List<DailyDownloads> Downloads);
