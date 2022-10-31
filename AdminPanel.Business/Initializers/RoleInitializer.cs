using AdminPanel.Abstractions.Core.Initialization;
using AdminPanel.Abstractions.Data.Services;

namespace AdminPanel.Business.Initializers
{
    internal class RoleInitializer : IInitializer
    {
        private readonly IRoleSeedService _roleSeedService;

        public RoleInitializer(IRoleSeedService roleSeedService)
        {
            _roleSeedService = roleSeedService;
        }

        public void Initialize() => _roleSeedService.Seed().GetAwaiter().GetResult();
    }
}
