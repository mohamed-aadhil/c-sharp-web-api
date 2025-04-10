using Microsoft.AspNetCore.Mvc;
using CRUD_API.Models;
using CRUD_API.Services;

namespace CRUD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_productService.GetAll());

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _productService.GetById(id);
            return product == null ? NotFound() : Ok(product);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            var newProduct = _productService.Add(product);
            return CreatedAtAction(nameof(Get), new { id = newProduct.Id }, newProduct);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            var result = _productService.Update(id, product);
            return result ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _productService.Delete(id);
            return result ? NoContent() : NotFound();
        }
    }
}
