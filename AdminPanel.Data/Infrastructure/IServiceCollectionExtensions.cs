using AdminPanel.Data.Contexts;
using AdminPanel.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdminPanel.Data.Infrastructure
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppUserIdentityContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentityCore<AppUser>(
                    options =>
                    {
                        options.SignIn.RequireConfirmedEmail = true;

                        options.Password.RequiredLength = 8;

                        options.User.RequireUniqueEmail = true;
                    })
                .AddEntityFrameworkStores<AppUserIdentityContext>();

            return services;
        }
    }
}