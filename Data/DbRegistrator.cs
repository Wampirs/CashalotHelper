using CashalotHelper.Providers.FileSystem;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CashalotHelper.Data
{
    static class DbRegistrator
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration Configuration) =>
            services
                .AddDbContext<HelperDb>(opt =>
                    {
                        opt.UseSqlite($"Data Source={FileSystem.MainDirectory}\\CashalotHelper.db");
                    }
                )
                .AddTransient<DbInitializer>()
                .AddRepositories()
            ;
    }
}
