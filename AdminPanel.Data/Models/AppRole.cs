using Microsoft.AspNetCore.Identity;

namespace AdminPanel.Data.Models
{
    internal class AppRole : IdentityRole
    {
        public IReadOnlyList<Permission> Permissions { get; set; } = Array.Empty<Permission>();
    }
}
