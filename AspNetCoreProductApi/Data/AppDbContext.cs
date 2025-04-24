using Microsoft.EntityFrameworkCore;
using AspNetCoreProductApi.Models;

namespace AspNetCoreProductApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(AppDbContextOptions<AppDbContext> options) : base(options) {}
        public DbSet<Product> Products {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product {Id = 1, Name = "Laptop", Price = 1200},
                new Product {Id = 2, Name = "Smartphone", Price = 850},
                new Product {Id = 3, Name = "Headphones", Price = 150}
            );
        }
    }
}