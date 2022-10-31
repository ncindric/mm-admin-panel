using AdminPanel.Abstractions.Data.Services;
using AdminPanel.Data.Contexts;
using AdminPanel.Data.Models;
using AdminPanel.Shared.Constants;

using Microsoft.AspNetCore.Identity;

namespace AdminPanel.Data.Services
{
    internal class PermissionSeedService : IPermissionSeedService
    {
        private readonly AppUserIdentityContext _context;

        public PermissionSeedService(AppUserIdentityContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {
            List<string> permissionsToAdd = new();
            var existingPermissions = _context.Permissions.ToList();
            foreach (var permission in PermissionNames.AllPermissions)
            {
                if (existingPermissions.Any(p => string.Equals(p.Name, permission)))
                {
                    continue;
                }

                permissionsToAdd.Add(permission);
            }

            if (permissionsToAdd is {Count: > 0})
            {
                await _context.Permissions.AddRangeAsync(permissionsToAdd.Select(p => new Permission
                {
                    Name = p,
                }));

                await _context.SaveChangesAsync();
            }
        }
    }
}
