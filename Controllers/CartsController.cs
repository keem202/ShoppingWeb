using Microsoft.AspNetCore.Mvc;
using OnlineShoppingAPI.Data;
using OnlineShoppingAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartsController : ControllerBase
    {
        private readonly ShoppingDbContext _context;

        public CartsController(ShoppingDbContext context)
        {
            _context = context;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<Cart>>> GetUserCart(int userId)
        {
            var carts = await _context.Carts.Where(c => c.UserId == userId).ToListAsync();
            return carts;
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(Cart cartItem)
        {
            // Assuming validation and other logic here
            _context.Carts.Add(cartItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserCart), new { userId = cartItem.UserId }, cartItem);
        }

        // Other actions for updating, deleting items from the cart, etc.
    }
}
