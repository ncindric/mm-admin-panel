using AdminPanel.Abstractions.Data.Services;

namespace AdminPanel.Web.Infrastructure
{
    public static class IApplicationBuilderExtensions
    {
        public static void UsePermissions(this IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var permissionInitializer = scope.ServiceProvider.GetRequiredService<IPermissionInitializer>();
            permissionInitializer.Initialize().GetAwaiter().GetResult();
        }
    }
}
