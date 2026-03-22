using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecommerece.Data;

namespace Ecommerece.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/products/bestsellers
        [HttpGet("bestsellers")]
        public async Task<IActionResult> GetBestSellers()
        {
            var products = await _context.Products
                .Where(p => p.IsBestSeller == true)
                .ToListAsync();

            return Ok(products);
        }
    }
}