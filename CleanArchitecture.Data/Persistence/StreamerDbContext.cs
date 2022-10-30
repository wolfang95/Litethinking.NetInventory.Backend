using Litethinking.NetInventory.Backend.Domain;
using Litethinking.NetInventory.Backend.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Litethinking.NetInventory.Backend.Infrastructure.Persistence
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options)
        {
        }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=localhost; 
        //        Initial Catalog=Company;user id=sa;password=VaxiDrez2025$")
        //    .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, Microsoft.Extensions.Logging.LogLevel.Information)
        //    .EnableSensitiveDataLogging();
        //}

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreationDate = DateTime.Now;
                        entry.Entity.CreatedBy = "system";
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "system";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .HasMany(m => m.Inventories)
                .WithOne(m => m.Company)
                .HasForeignKey(m => m.CompanyId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);



            modelBuilder.Entity<Inventory>()
                .HasMany(p => p.Products)
                .WithMany(t => t.Inventories);
                /*.UsingEntity<Litethinking.NetInventory.Backend.Domain.InventoryProduct>(
                    pt => pt.HasKey(e => new { e.ProductId, e.InventoryId })
                );
                */
            
                

        }


        public DbSet<Company>? Companies { get; set; }

        public DbSet<Inventory>? Inventories { get; set; }

        public DbSet<Product>? Products { get; set; }

        public DbSet<Director>? Directores { get; set; }

    }
}
