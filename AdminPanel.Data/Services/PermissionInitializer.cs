using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AdminPanel.Abstractions.Data.Services;
using AdminPanel.Data.Contexts;
using AdminPanel.Data.Models;
using AdminPanel.Shared.Constants;

using Microsoft.AspNetCore.Identity;

namespace AdminPanel.Data.Services
{
    internal class PermissionInitializer : IPermissionInitializer
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly AppUserIdentityContext _context;

        public PermissionInitializer(
            RoleManager<AppRole> roleManager,
            AppUserIdentityContext context)
        {
            _roleManager = roleManager;
            _context = context;
        }

        public async Task Initialize()
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
