using ApexCharts;
using NuGetTrends.Portal.Components;

namespace NuGetTrends.Portal.Themes;

public static class ChartTheme
{
    public static readonly ApexChartOptions<PackageChart.ChartDataPoint> Theme = new()
    {
        Theme = new() { Mode = Mode.Light, Palette = PaletteType.Palette1 },
        Chart = new()
        {
            Type = ChartType.Pie,
            Height = 400,
            FontFamily = "Roboto, Helvetica, Arial, sans-serif",
            Toolbar = new()
            {
                Show = false,
            },
            Animations = new() { Enabled = true, Easing = Easing.Easeout, Speed = 800 }
        },
        Stroke = new() { Width = new List<int> { 3 }, Curve = Curve.Smooth },
        Grid = new() { Show = true, BorderColor = "#e0e0e0", StrokeDashArray = 3 },
        Xaxis =
            new()
            {
                Type = XAxisType.Datetime,
                Labels =
                    new()
                    {
                        DatetimeFormatter = new()
                        {
                            Year = "yyyy", Month = "MMM 'yy", Day = "dd MMM 'yy", Hour = "HH:mm"
                        }
                    }
            },
        Yaxis =
        [
            new YAxis
            {
                Labels = new() { Formatter = "function(value) { return value.toLocaleString(); }" }
            }
        ],
        Tooltip = new()
        {
            Enabled = true,
            Shared = true,
            Intersect = false,
            X = new() { Format = "dd MMM yyyy" },
            Y = new() { Formatter = "function(value) { return value.toLocaleString() + ' downloads'; }" }
        },
        Legend = new()
        {
            Show = true,
            Position = LegendPosition.Top,
            HorizontalAlign = Align.Center,
            FontSize = "14px",
            FontWeight = "500",
        },
        Colors =
        [
            "#1976d2",
            "#dc004e",
            "#00c853",
            "#ff6d00",
            "#6a1b9a",
            "#d32f2f",
            "#1565c0",
            "#2e7d32"
        ]
    };

    public static void SetChartType(this ChartType chartType) => Theme.Chart.Type = chartType;
}
