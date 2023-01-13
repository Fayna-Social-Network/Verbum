using Microsoft.Extensions.DependencyInjection;

namespace Verbum.Application.UserGrops.Repositories
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUserGroupsRepositories(this IServiceCollection services)
        {

            services.AddTransient<UserGroupsHubRepository>();

            return services;
        }
    }
}
