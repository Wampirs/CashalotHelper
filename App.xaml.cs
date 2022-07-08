using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;
using CashalotHelper.Data;
using CashalotHelper.Services;
using CashalotHelper.ViewModels;
using CashalotHelper.Providers;
using CashalotHelper.Providers.Settings;
using CashalotHelper.Providers.FileSystem;

namespace CashalotHelper
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static SettingsProvider _settings; 
        private static IHost _host;
        public static IHost Host => _host ??=Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();
        public static SettingsProvider Settings => _settings ??= Services.CreateScope().ServiceProvider.GetRequiredService<SettingsProvider>();
        public static IServiceProvider Services => Host.Services;

        internal static void ConfigureServices(HostBuilderContext host, IServiceCollection services) => services
            .AddFileSystem()
            .AddDatabase(host.Configuration.GetSection("Database"))
            .AddProviders()
            .AddServices()
            .AddViewModels()
        ;

        protected override async void OnStartup(StartupEventArgs e)
        {
            var host = Host;

            using (var scope = Services.CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<FileSystemInitializer>().Initialize();
                scope.ServiceProvider.GetRequiredService<DbInitializer>().InitializeAsync().Wait();
            }
            base.OnStartup(e);
            await host.StartAsync();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            var host = Host;
            base.OnExit(e);
            await host.StopAsync();
        }
    }
}
