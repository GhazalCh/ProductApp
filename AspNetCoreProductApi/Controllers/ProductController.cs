using Microsoft.AspNetCore.Mvc;
using AspNetCoreProductApi.Models;
using AspNetCoreProductApi.Data;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreProductApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProductController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _context.Products.ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var prod = await -_context.Products.FindAsync(id);
            return prod == null ? NotFound() : Ok(prod);
        }

        [HttpPost]
        public async Task<IactionResult> Create(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return CreateAtAction(nameof(Get), new {id = product.Id}, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Product updated)
        {
            var prod = await _context.Products.FindAsync(id);
            if (prod == null) return NotFound();
            prod.Name = updated.Name;
            prod.Price = updated.Price;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var prod = await _context.Products.FindAsync(id);
            if (prod == null) return NotFound();
            _context.Products.Remove(prod);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
