using Microsoft.Extensions.DependencyInjection;

namespace CashalotHelper.ViewModels
{
    class ViewModelLocator
    {
        public static MainWindowViewModel MainWindowViewModel => App.Services.GetRequiredService<MainWindowViewModel>();
        public static BackupManagerViewModel BackupManagerViewModel => App.Services.GetRequiredService<BackupManagerViewModel>();
        public static SettingsViewModel SettingsViewModel => App.Services.GetRequiredService<SettingsViewModel>();
    }
}
