using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecommerece.Data;
using Ecommerece.Models;

namespace Ecommerece.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CartController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/cart
        [HttpPost]
        public async Task<IActionResult> AddToCart(
            int userId,
            int productId,
            int quantity)
        {
            var cartItem = await _context.Carts
                .FirstOrDefaultAsync(x =>
                    x.UserId == userId &&
                    x.ProductId == productId);

            if (cartItem != null)
            {
                cartItem.Quantity += quantity;
            }
            else
            {
                cartItem = new Cart
                {
                    UserId = userId,
                    ProductId = productId,
                    Quantity = quantity,
                    CreatedDate = DateTime.Now
                };

                _context.Carts.Add(cartItem);
            }

            await _context.SaveChangesAsync();

            return Ok("Product added to cart");
        }
    }
}