using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecommerece.Data;
using Ecommerece.Models;

namespace Ecommerece.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouriteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FavouriteController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/favourite/addtofavourite
        [HttpPost("addtofavourite")]
        public async Task<IActionResult> AddToFavourite(
            int userId,
            int productId)
        {
            var favourite = new Favourite
            {
                UserId = userId,
                ProductId = productId,
                CreatedDate = DateTime.Now
            };

            _context.Favourites.Add(favourite);

            await _context.SaveChangesAsync();

            return Ok("Added to favourite");
        }

        // DELETE: api/favourite/remove/{productId}
        [HttpDelete("remove/{productId}")]
        public async Task<IActionResult> RemoveFavourite(
            int productId,
            int userId)
        {
            var favourite = await _context.Favourites
                .FirstOrDefaultAsync(x =>
                    x.ProductId == productId &&
                    x.UserId == userId);

            if (favourite == null)
                return NotFound("Favourite not found");

            _context.Favourites.Remove(favourite);

            await _context.SaveChangesAsync();

            return Ok("Removed from favourite");
        }
    }
}