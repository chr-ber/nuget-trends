using System.Data.SqlTypes;
using Blazored.LocalStorage;
using NuGetTrends.Portal.Models;

namespace NuGetTrends.Portal.Services;

public class UserInterfaceService(ILocalStorageService localStorageService) : IUserInterfaceService
{
    private const string StorageKey = nameof(UserSettings);
    private const bool DarkModeByDefault = true;
    private const bool RTLByDefault = true;

    private UserSettings? _userSettings;

    public event EventHandler? UserInterfaceChanged;

    public bool IsDarkMode => _userSettings?.UseDarkMode ?? DarkModeByDefault;

    public bool IsRTL => _userSettings?.UseRTL ?? RTLByDefault;

    public async Task InitializeUserSettingsAsync(bool systemUsesDarkMode)
    {
        _userSettings = await localStorageService.GetItemAsync<UserSettings>(StorageKey)
                        ?? new UserSettings(systemUsesDarkMode, IsRTL);
        OnUserInterfaceChanged();
    }

    public async Task ToggleDarkMode() => await SetDarkMode(!IsDarkMode);

    public async Task ToggleRTL() => await SetRTL(!IsRTL);

    public async Task SetDarkMode(bool useDarkMode)
    {
        _userSettings = _userSettings! with { UseDarkMode = useDarkMode };
        await localStorageService.SetItemAsync(StorageKey, _userSettings);
        OnUserInterfaceChanged();
    }

    private async Task SetRTL(bool useRTL)
    {
        _userSettings = _userSettings! with { UseRTL = useRTL };
        await localStorageService.SetItemAsync(StorageKey, _userSettings);
        OnUserInterfaceChanged();
    }

    private void OnUserInterfaceChanged() => UserInterfaceChanged?.Invoke(this, EventArgs.Empty);
}
