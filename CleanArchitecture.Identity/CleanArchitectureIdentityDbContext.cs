using Litethinking.NetInventory.Backend.Identity.Configurations;
using Litethinking.NetInventory.Backend.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Litethinking.NetInventory.Backend.Identity
{
    public class CleanArchitectureIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public CleanArchitectureIdentityDbContext(DbContextOptions<CleanArchitectureIdentityDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}
