using Microsoft.Extensions.DependencyInjection;

namespace CashalotHelper.Providers.FileSystem
{
    static class FileSysyemRegistrator
    {
        public static IServiceCollection AddFileSystem(this IServiceCollection services) => services
            .AddTransient<FileSystemInitializer>()
        ;
    }
}
