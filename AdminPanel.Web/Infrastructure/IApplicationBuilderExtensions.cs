using AdminPanel.Abstractions.Core.Initialization;

namespace AdminPanel.Web.Infrastructure
{
    public static class IApplicationBuilderExtensions
    {
        public static void UsePermissions(this IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();

            foreach (var initializer in scope.ServiceProvider.GetServices<IInitializer>())
            {
                initializer.Initialize();
            }
        }
    }
}
