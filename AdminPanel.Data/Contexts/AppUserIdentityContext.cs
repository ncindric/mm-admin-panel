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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Permission>()
                .HasMany(p => p.Roles)
                .WithMany(r => r.Permissions);
        }
    }
}