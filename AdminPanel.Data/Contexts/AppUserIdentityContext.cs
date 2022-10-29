using AdminPanel.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdminPanel.Data.Contexts
{
    internal class AppUserIdentityContext : IdentityDbContext<AppUser>
    {
        public AppUserIdentityContext(DbContextOptions<AppUserIdentityContext> options)
            : base(options)
        {
        }
    }
}