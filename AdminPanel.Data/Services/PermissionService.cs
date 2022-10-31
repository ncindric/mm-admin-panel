using AdminPanel.Abstractions.Core;
using AdminPanel.Abstractions.Core.Results;
using AdminPanel.Abstractions.Data.Models.Permissions;
using AdminPanel.Abstractions.Data.Models.Roles;
using AdminPanel.Abstractions.Data.Services;
using AdminPanel.Data.Contexts;

using Microsoft.EntityFrameworkCore;

namespace AdminPanel.Data.Services
{
    internal class PermissionService : IPermissionService
    {
        private readonly AppUserIdentityContext _context;

        public PermissionService(AppUserIdentityContext context)
        {
            _context = context;
        }

        public IReadOnlyList<PermissionDto> Get() => _context.Permissions
            .Include(p => p.Roles)
            .AsEnumerable()
            .Select(p => new PermissionDto()
            {
                Id = p.Id,
                Name = p.Name,
                Roles = p.Roles.Select(r => new RoleDto
                {
                    Id = r.Id,
                    Name = r.Name,
                }).ToList(),
            }).ToList();

        public PermissionDto? Get(int id)
        {
            var permission = _context.Permissions
                .Include(p => p.Roles)
                .FirstOrDefault(i => i.Id == id);
            return permission == null
                ? default
                : new PermissionDto
                {
                    Id = permission.Id,
                    Name = permission.Name,
                    Roles = permission.Roles.Select(r => new RoleDto
                    {
                        Id = r.Id,
                        Name = r.Name,
                    }).ToList(),
                };
        }

        public Result Update(PermissionDto permission)
        {
            var original = _context.Permissions.Find(permission.Id);
            if (original == null)
            {
                return ResultFactory.Failure("Permission not found");
            }

            original.Roles = _context.Roles.AsEnumerable()
                .Where(r => permission.Roles.Any(p => string.Equals(r.Id, p.Id)))
                .ToList();

            _context.SaveChanges();

            return ResultFactory.Success();
        }
    }
}
