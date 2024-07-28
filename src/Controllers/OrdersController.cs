using Microsoft.AspNetCore.Mvc;
using OnlineShoppingAPI.Data;
using OnlineShoppingAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace OnlineShoppingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Apply authorization at the controller level
    public class OrdersController : ControllerBase
    {
        private readonly ShoppingDbContext _context;

        public OrdersController(ShoppingDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            // Only authenticated users can access this endpoint due to [Authorize] attribute
            return await _context.Orders.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(Order order)
        {
            // Only authenticated users can access this endpoint due to [Authorize] attribute
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrder), new { id = order.OrderId }, order);
        }

    }
}
