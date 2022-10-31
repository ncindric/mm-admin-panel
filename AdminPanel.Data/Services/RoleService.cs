using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminPanel.Abstractions.Data.Models.Roles;
using AdminPanel.Abstractions.Data.Services;
using AdminPanel.Data.Contexts;

namespace AdminPanel.Data.Services
{
    internal class RoleService : IRoleService
    {
        private readonly AppUserIdentityContext _context;

        public RoleService(AppUserIdentityContext context)
        {
            _context = context;
        }

        public IReadOnlyList<RoleDto> Get()
        {
            return _context.Roles.Select(r => new RoleDto
            {
                Id = r.Id,
                Name = r.Name,
            }).ToList();
        }
    }
}
