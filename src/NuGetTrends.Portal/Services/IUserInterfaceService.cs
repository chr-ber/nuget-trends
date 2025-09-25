namespace NuGetTrends.Portal.Services;

public interface IUserInterfaceService
{
    event EventHandler? UserInterfaceChanged;
    bool IsDarkMode { get; }
    bool IsRTL { get; }
    Task ToggleDarkMode();
    Task ToggleRTL();
    Task InitializeUserSettingsAsync(bool systemUsesDarkMode);
    Task SetDarkMode(bool useDarkMode);
}
