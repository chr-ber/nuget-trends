namespace NuGetTrends.Portal.Models;

public class Aggregation
{
    public required AggregationOption Option { get; init; }
    public required string  DisplayName { get; init; }

    public static readonly List<Aggregation> All =
    [
        new() { Option = AggregationOption.Cumulative, DisplayName = "Cumulative"},
        new() { Option = AggregationOption.WeeklyChange, DisplayName = "Weekly Change" },
    ];

    public static Aggregation Default => All.First(t => t.Option == AggregationOption.Cumulative);

    public static Aggregation GetByOption(AggregationOption option) => All.First(t => t.Option == option);

    public override string ToString()
    {
        return DisplayName;
    }
}

public enum AggregationOption
{
    Cumulative,
    WeeklyChange
}

