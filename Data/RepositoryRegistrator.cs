using CashalotHelper.Data.Entities;
using CashalotHelper.Data.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CashalotHelper.Data
{
    static class RepositoryRegistrator
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services) => services
            .AddTransient<IRepository<Backup>, DbRepository<Backup>>()
            .AddTransient<IConfigRepository<Configuration>, ConfigurationRepository<Configuration>>()
        ;
    }
}
