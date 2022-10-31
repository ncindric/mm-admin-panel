using Microsoft.AspNetCore.Identity;

namespace AdminPanel.Data.Models
{
    internal class AppRole : IdentityRole
    {
        public List<Permission> Permissions { get; set; } = new();
    }
}
