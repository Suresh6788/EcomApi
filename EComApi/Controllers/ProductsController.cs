using EComApi.Data;
using EComApi.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EComApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/products
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }

        // GET: api/products/5
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
                return NotFound($"Product with ID {id} not found.");

            return Ok(product);
        }

        // POST: api/products
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Products.Add(product);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        // GET: api/products/update/5 (optional for UI forms)
        [HttpGet("update/{id}")]
        public IActionResult GetProductForUpdate(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
                return NotFound($"Product with ID {id} not found.");

            return Ok(product);
        }

        // POST: api/products/update
        [HttpPost("update")]
        public IActionResult UpdateProduct(Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingProduct = _context.Products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct == null)
                return NotFound($"Product with ID {product.Id} not found.");

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Brand = product.Brand;
            existingProduct.PictureUrl = product.PictureUrl;
            existingProduct.Price = product.Price;
            existingProduct.QuantityInStock = product.QuantityInStock;
            existingProduct.Type = product.Type;

            _context.SaveChanges();

            return Ok(existingProduct);
        }

        // DELETE: api/products/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
                return NotFound($"Product with ID {id} not found.");

            _context.Products.Remove(product);
            _context.SaveChanges();

            return Ok($"Product with ID {id} deleted successfully.");
            // changed for azure
        }
    }
}
