using Microsoft.Extensions.DependencyInjection;

namespace Verbum.Application.Verbum.Repositories
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddVerbumRepositories(this IServiceCollection services) {

            services.AddTransient<FilesRepository>();
            services.AddTransient<VerbumHubRepository>();
            
            return services;
        }
    }
}
