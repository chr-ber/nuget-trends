using MudBlazor;

namespace NuGetTrends.Portal.Themes;

public static class SiteTheme
{
    public static readonly MudTheme Theme = new()
    {
        PaletteLight = new PaletteLight()
        {
            Primary = "#1976d2",
            Secondary = "#424242",
            Background = "#f5f5f5",
            Surface = "#ffffff",
            Success = "#4caf50",
            Info = "#2196f3",
            Warning = "#ff9800",
            Error = "#f44336",
            Dark = "#424242",
            TextPrimary = "rgba(0,0,0, 0.87)",
            TextSecondary = "rgba(0,0,0, 0.6)",
            ActionDefault = "rgba(0,0,0, 0.54)",
            ActionDisabled = "rgba(0,0,0, 0.26)",
            ActionDisabledBackground = "rgba(0,0,0, 0.12)",
            Divider = "rgba(0,0,0, 0.12)",
        },
        PaletteDark = new PaletteDark()
        {
            Primary = "#90caf9",
            Secondary = "#f48fb1",
            Background = "#121212",
            Surface = "#1e1e1e",
            Success = "#81c784",
            Info = "#64b5f6",
            Warning = "#ffb74d",
            Error = "#e57373",
            Dark = "#f5f5f5",
            TextPrimary = "rgba(255,255,255, 0.87)",
            TextSecondary = "rgba(255,255,255, 0.6)",
            ActionDefault = "rgba(255,255,255, 0.54)",
            ActionDisabled = "rgba(255,255,255, 0.26)",
            ActionDisabledBackground = "rgba(255,255,255, 0.12)",
            Divider = "rgba(255,255,255, 0.12)"
        },
    };
}
