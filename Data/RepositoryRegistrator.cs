using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashalotHelper.Data.Entities;
using CashalotHelper.Data.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CashalotHelper.Data
{
    static class RepositoryRegistrator
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services) => services
            .AddTransient<IRepository<Backup>,DbRepository<Backup>>()
            .AddTransient<IConfigRepository<Configuration>,ConfigurationRepository<Configuration>>()
        ;
    }
}
