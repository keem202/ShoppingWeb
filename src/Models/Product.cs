namespace OnlineShoppingAPI.Models;

public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public string Category { get; set; }
    public string ImageUrl { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<Cart> Carts { get; set; }
}
