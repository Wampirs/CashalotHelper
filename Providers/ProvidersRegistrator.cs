using CashalotHelper.Providers.Interfaces;
using CashalotHelper.Providers.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace CashalotHelper.Providers
{
    public static class ProvidersRegistrator
    {
        public static IServiceCollection AddProviders(this IServiceCollection services) => services
            .AddSingleton<ISettingsProvider, SettingsProvider>()
            .AddSingleton<ICashalotProvider, CashalotProvider>()
            ;
    }
}
