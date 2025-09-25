namespace NuGetTrends.Portal.Models;

public class TimeRange
{
    public required TimeRangeOption Option { get; init; }
    public required string  DisplayName { get; init; }
    public required int MonthsBack { get; init; }

    public static readonly List<TimeRange> All =
    [
        new() { Option = TimeRangeOption.OneMonth, DisplayName = "1 Month", MonthsBack = 1 },
        new() { Option = TimeRangeOption.ThreeMonths, DisplayName = "3 Months", MonthsBack = 3 },
        new() { Option = TimeRangeOption.SixMonths, DisplayName = "6 Months", MonthsBack = 6 },
        new() { Option = TimeRangeOption.OneYear, DisplayName = "1 Year", MonthsBack = 12 },
        new() { Option = TimeRangeOption.TwoYears, DisplayName = "2 Years", MonthsBack = 24 },
        new() { Option = TimeRangeOption.FiveYears, DisplayName = "5 Years", MonthsBack = 60 },
        new() { Option = TimeRangeOption.TenYears, DisplayName = "10 Years", MonthsBack = 120 }
    ];

    public static TimeRange Default => All.First(t => t.Option == TimeRangeOption.OneYear);

    public static TimeRange GetByOption(TimeRangeOption option) => All.First(t => t.Option == option);

    public override string ToString()
    {
        return DisplayName;
    }
}

public enum TimeRangeOption
{
    OneMonth,
    ThreeMonths,
    SixMonths,
    OneYear,
    TwoYears,
    FiveYears,
    TenYears
}

