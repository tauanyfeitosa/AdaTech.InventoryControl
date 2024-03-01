using AdaTech.InventoryControl.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdaTech.InventoryControl.DateLibrary
{
    public class InventoryControlContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Batch> Batches { get; set; }

        public InventoryControlContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            builder.Entity<Product>().HasKey(p => p.Id);
            builder.Entity<Batch>().HasKey(b => b.Id);
            builder.Entity<Product>().HasMany(p => p.Batches).WithOne(b => b.Product).HasForeignKey(b => b.ProductId);
        }
    }
}
