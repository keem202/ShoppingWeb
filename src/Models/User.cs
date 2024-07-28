using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace OnlineShoppingAPI.Models
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Cart> Carts { get; set; }
    }
}
