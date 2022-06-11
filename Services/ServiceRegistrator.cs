using CashalotHelper.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CashalotHelper.Services
{
    public static class ServiceRegistrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services
            .AddTransient<IArchivatorService,ArchivatorService>()
        ;
    }
}
