using Microsoft.AspNetCore.Identity;

namespace AdminPanel.Data.Models
{
    internal class AppUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;
    }
}