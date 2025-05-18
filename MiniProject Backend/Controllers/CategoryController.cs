using Microsoft.AspNetCore.Mvc;
using MiniProject.Models;
using MiniProject.Service.Category;

namespace MiniProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategory _service;

        public CategoriesController(ICategory service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await _service.GetAllCategories();
            return result.Result ?? Ok(result.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var result = await _service.GetCategory(id);
            return result.Result ?? Ok(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] Category category)
        {
            var result = await _service.AddCategory(category);
            return result.Result ?? CreatedAtAction(nameof(GetCategory),
                                                    new { id = ((dynamic)result.Value).Id },
                                                    result.Value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _service.DeleteCategory(id);
            return result.Result ?? Ok(result.Value);
        }
    }
}
