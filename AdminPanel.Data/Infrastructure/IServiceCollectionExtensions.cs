using AdminPanel.Abstractions.Data.Services;
using AdminPanel.Data.Contexts;
using AdminPanel.Data.Models;
using AdminPanel.Data.Services;
using Microsoft.AspNetCore.Identity;
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
            services.AddIdentity<AppUser, AppRole>(
                    options =>
                    {
                        options.SignIn.RequireConfirmedEmail = true;

                        options.Password.RequiredLength = 8;

                        options.User.RequireUniqueEmail = true;
                    })
                .AddEntityFrameworkStores<AppUserIdentityContext>()
                .AddSignInManager<SignInManager<AppUser>>()
                .AddUserManager<UserManager<AppUser>>()
                .AddPasswordValidator<PasswordValidator<AppUser>>()
                .AddDefaultTokenProviders();

            services.AddTransient<IAuthenticationService, AuthenticationService>();

            return services;
        }
    }
}