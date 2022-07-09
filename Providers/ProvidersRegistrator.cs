﻿using CashalotHelper.Providers.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using CashalotHelper.Providers.Settings;

namespace CashalotHelper.Providers
{
    public static class ProvidersRegistrator
    {
        public static IServiceCollection AddProviders(this IServiceCollection services) => services
            .AddTransient<SettingsProvider>()
            .AddSingleton<ICashalotProvider,CashalotProvider>()
            ;
    }
}
