using AdminPanel.Abstractions.Core.Initialization;
using AdminPanel.Business.Initializers;
using Microsoft.Extensions.DependencyInjection;

namespace AdminPanel.Business.Infrastructure
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            services.AddTransient<IInitializer, PermissionInitializer>();
            services.AddTransient<IInitializer, RoleInitializer>();

            return services;
        }
    }
}
