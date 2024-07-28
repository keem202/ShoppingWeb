using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingAPI.Models;

namespace OnlineShoppingAPI.Data
{
    public class ShoppingDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Cart> Carts { get; set; }

        public ShoppingDbContext(DbContextOptions<ShoppingDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Ensure Identity tables are created

            // Define relationships and constraints
            modelBuilder.Entity<OrderDetail>()
                .HasKey(od => new { od.OrderId, od.ProductId });

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(od => od.ProductId);

            modelBuilder.Entity<Cart>()
                .HasKey(c => new { c.UserId, c.ProductId });

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.User)
                .WithMany(u => u.Carts)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.Product)
                .WithMany(p => p.Carts)
                .HasForeignKey(c => c.ProductId);

            // Seed data
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    Name = "High-End Gaming Laptop",
                    Description = "Powerful laptop with NVIDIA GeForce RTX 3080, 16GB RAM, and 1TB SSD.",
                    Price = 1999.99m,
                    StockQuantity = 10,
                    Category = "Electronics",
                    ImageUrl = "https://example.com/images/gaming-laptop.jpg"
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Latest Smartphone",
                    Description = "Smartphone with a 108MP camera, 12GB RAM, and 256GB storage.",
                    Price = 899.99m,
                    StockQuantity = 25,
                    Category = "Electronics",
                    ImageUrl = "https://example.com/images/latest-smartphone.jpg"
                },
                new Product
                {
                    ProductId = 3,
                    Name = "10.2-inch Tablet",
                    Description = "Tablet with 4GB RAM, 64GB storage, and a high-resolution display.",
                    Price = 349.99m,
                    StockQuantity = 15,
                    Category = "Electronics",
                    ImageUrl = "https://example.com/images/10-inch-tablet.jpg"
                },
                new Product
                {
                    ProductId = 4,
                    Name = "Fitness Smartwatch",
                    Description = "Smartwatch with heart rate monitoring, GPS, and water resistance.",
                    Price = 199.99m,
                    StockQuantity = 30,
                    Category = "Electronics",
                    ImageUrl = "https://example.com/images/fitness-smartwatch.jpg"
                },
                new Product
                {
                    ProductId = 5,
                    Name = "Noise-Cancelling Wireless Earbuds",
                    Description = "Earbuds with active noise cancellation, Bluetooth 5.0, and long battery life.",
                    Price = 129.99m,
                    StockQuantity = 40,
                    Category = "Electronics",
                    ImageUrl = "https://example.com/images/noise-cancelling-earbuds.jpg"
                }
            );
        }
    }
}
