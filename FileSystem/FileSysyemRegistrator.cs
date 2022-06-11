using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace CashalotHelper.FileSystem
{
    static class FileSysyemRegistrator
    {
        public static IServiceCollection AddFileSystem(this IServiceCollection services) => services
            .AddTransient<FileSystemInitializer>()
        ;
    }
}
