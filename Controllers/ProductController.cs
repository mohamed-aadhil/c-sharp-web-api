using Microsoft.AspNetCore.Authorization; // Required for [Authorize]
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.AspNetCore.Mvc;
using CRUD_API.Models;
using CRUD_API.Services;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CRUD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize] // Protects all endpoints in this controller
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        
        [HttpGet]
        [Authorize]
        [EnableRateLimiting("ProductPolicy")]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<Product>> Post([FromBody] Product product)
        {
            var created = await _productService.AddAsync(product);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Product product)
        {
            var updated = await _productService.UpdateAsync(id, product);
            if (!updated)
                return NotFound();
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _productService.DeleteAsync(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
}
