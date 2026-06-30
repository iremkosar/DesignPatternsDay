using DesignPatternsDay.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesignPatternsDay.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Trend> Trends { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                 new Product { Id = 1, Name = "Organic Cabbage", Category = "Vegetables", Price = 50, Stock = 100, IsOrganic = true },
                new Product { Id = 2, Name = "Beef Steak", Category = "Meats", Price = 150, Stock = 30, IsOrganic = false },
                new Product { Id = 3, Name = "Mango Juice", Category = "Beverages", Price = 25, Stock = 5, IsOrganic = true },
                new Product { Id = 4, Name = "Broccoli", Category = "Vegetables", Price = 35, Stock = 80, IsOrganic = true },
                new Product { Id = 5, Name = "Strawberries", Category = "Fruits", Price = 45, Stock = 0, IsOrganic = false }
                );
        }
    }
}
