using Microsoft.AspNetCore.Mvc;
using MiniProject.Models;
using MiniProject.Service.Product;

namespace MiniProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProduct _service;

        public ProductsController(IProduct service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _service.GetAllProducts();
            return result.Result ?? Ok(result.Value);
        }

        [HttpGet("category/{name}")]
        public async Task<IActionResult> GetByCategory(string name)
        {
            var result = await _service.GetProductsByCategory(name);
            return result.Result ?? Ok(result.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var result = await _service.GetProduct(id);
            return result.Result ?? Ok(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            var result = await _service.AddProduct(product);
            return result.Result ?? CreatedAtAction(nameof(GetProduct),
                                                    new { id = ((dynamic)result.Value).Id },
                                                    result.Value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _service.DeleteProduct(id);
            return result.Result ?? Ok(result.Value);
        }
    }
}
