using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShoppingAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Category", "Description", "ImageUrl", "Name", "Price", "StockQuantity" },
                values: new object[,]
                {
                    { 1, "Electronics", "Powerful laptop with NVIDIA GeForce RTX 3080, 16GB RAM, and 1TB SSD.", "https://example.com/images/gaming-laptop.jpg", "High-End Gaming Laptop", 1999.99m, 10 },
                    { 2, "Electronics", "Smartphone with a 108MP camera, 12GB RAM, and 256GB storage.", "https://example.com/images/latest-smartphone.jpg", "Latest Smartphone", 899.99m, 25 },
                    { 3, "Electronics", "Tablet with 4GB RAM, 64GB storage, and a high-resolution display.", "https://example.com/images/10-inch-tablet.jpg", "10.2-inch Tablet", 349.99m, 15 },
                    { 4, "Electronics", "Smartwatch with heart rate monitoring, GPS, and water resistance.", "https://example.com/images/fitness-smartwatch.jpg", "Fitness Smartwatch", 199.99m, 30 },
                    { 5, "Electronics", "Earbuds with active noise cancellation, Bluetooth 5.0, and long battery life.", "https://example.com/images/noise-cancelling-earbuds.jpg", "Noise-Cancelling Wireless Earbuds", 129.99m, 40 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);
        }
    }
}
