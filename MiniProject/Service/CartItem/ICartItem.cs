using Microsoft.AspNetCore.Mvc;

namespace MiniProject.Service.CartItem
{
    public interface ICartItem
    {
        Task<ActionResult<IEnumerable<Models.CartItem>>> GetCart(int userId);
        Task<ActionResult<Models.CartItem>> AddToCart(int userId, int productId, int qty = 1);
        Task<ActionResult<Models.CartItem>> RemoveFromCart(int userId, int productId);
        Task<ActionResult> ClearCart(int userId);
        Task<ActionResult<decimal>> Checkout(int userId);
    }
}
