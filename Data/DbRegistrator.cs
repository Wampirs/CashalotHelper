using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                        var DbPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                                     "\\BackupManager\\CashalotHelper.db";
                        opt.UseSqlite($"Data Source={DbPath}");
                    }
                )
                .AddTransient<DbInitializer>()
            ;
    }
}
