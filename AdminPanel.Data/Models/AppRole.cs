using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AdminPanel.Data.Models
{
    internal class AppRole : IdentityRole
    {
        public IReadOnlyList<Permission> Permissions { get; set; } = Array.Empty<Permission>();
    }
}
