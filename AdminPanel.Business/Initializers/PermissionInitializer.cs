using AdminPanel.Abstractions.Core.Initialization;
using AdminPanel.Abstractions.Data.Services;

namespace AdminPanel.Business.Initializers
{
    internal class PermissionInitializer : IInitializer
    {
        private readonly IPermissionSeedService _permissionSeedService;

        public PermissionInitializer(IPermissionSeedService permissionSeedService)
        {
            _permissionSeedService = permissionSeedService;
        }

        public void Initialize() => _permissionSeedService.Seed().GetAwaiter().GetResult();
    }
}
