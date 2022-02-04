using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Verbum.Application.Interfaces;

#nullable disable
namespace Verbum.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistans(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<VerbumDbContext>(options => {
                options.UseNpgsql(connectionString, b => b.MigrationsAssembly("Verbum.WebApi"));
            });
            services.AddScoped<IVerbumDbContext>(provider => provider.GetService<VerbumDbContext>());

            return services;
        }
    }
}
