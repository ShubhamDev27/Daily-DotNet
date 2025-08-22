using Microsoft.AspNetCore.Mvc;
using MiniProject.Service.CartItem;

namespace MiniProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartItem _service;

        public CartController(ICartItem service)
        {
            _service = service;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetCart(int userId)
        {
            var result = await _service.GetCart(userId);
            return result.Result ?? Ok(result.Value);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddToCart(int userId, int productId, int qty = 1)
        {
            var result = await _service.AddToCart(userId, productId, qty);
            return result.Result ?? Ok(result.Value);
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> RemoveFromCart(int userId, int productId)
        {
            var result = await _service.RemoveFromCart(userId, productId);
            return result.Result ?? Ok(result.Value);
        }

        [HttpDelete("clear/{userId}")]
        public async Task<IActionResult> ClearCart(int userId)
        {
            var result = await _service.ClearCart(userId);
            return result;
        }

        [HttpPost("checkout/{userId}")]
        public async Task<IActionResult> Checkout(int userId)
        {
            var result = await _service.Checkout(userId);
            return result.Result ?? Ok(new { total = result.Value });
        }
    }
}
