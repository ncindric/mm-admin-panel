using AdminPanel.Abstractions.Data.Services;
using AdminPanel.Data.Models;
using AdminPanel.Shared.Constants;
using Microsoft.AspNetCore.Identity;

namespace AdminPanel.Data.Services
{
    internal class RoleSeedService : IRoleSeedService
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleSeedService(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            foreach (var role in RoleNames.AllRoles)
            {
                if (await _roleManager.FindByNameAsync(role) != null)
                {
                    continue;
                }

                await _roleManager.CreateAsync(new AppRole
                {
                    Name = role,
                    NormalizedName = _roleManager.NormalizeKey(role),
                });
            }
        }
    }
}
