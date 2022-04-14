using Microsoft.EntityFrameworkCore;
using Shop.API.Models;

namespace Shop.API.Repository
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(a => a.Category)
            .HasForeignKey(a => a.CategoryId);

            modelBuilder.Entity<Stock>()
            .HasOne<Product>(s => s.Product)
            .WithOne(a => a.Stock)
            .HasForeignKey<Product>(s => s.StockId);

            modelBuilder.Seed();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Stock> Stocks { get; set; }

    }


}