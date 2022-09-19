using Microsoft.Extensions.DependencyInjection;

namespace CashalotHelper.ViewModels
{
    public static class ViewModelRegistrator
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services) => services
            .AddSingleton<MainWindowViewModel>()
            .AddSingleton<BackupManagerViewModel>()
            .AddSingleton<SettingsViewModel>()

        ;
    }
}
