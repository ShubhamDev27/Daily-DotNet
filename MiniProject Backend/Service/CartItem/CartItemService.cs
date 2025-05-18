using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniProject.Repository;

namespace MiniProject.Service.CartItem
{
    public class CartItemService : ICartItem
    {
        private readonly AppDbContext _db;
        public CartItemService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<ActionResult<IEnumerable<Models.CartItem>>> GetCart(int userId)
        {
            var item = await _db.CartItems.Include(ci => ci.Product)
                                          .Where(ci => ci.UserId == userId)
                                          .ToListAsync();
            return item;
        }

        public async Task<ActionResult<Models.CartItem>> AddToCart(int userId, int productId, int qty = 1)
        {
            var item = await _db.CartItems
                                 .FirstOrDefaultAsync(ci => ci.UserId == userId && ci.ProductId == productId);

            if (item is null)
            {
                item = new Models.CartItem { UserId = userId, ProductId = productId, Quantity = qty };
                _db.CartItems.Add(item);
            }
            else
            {
                item.Quantity += qty;
            }

            await _db.SaveChangesAsync();
            return item;
        }

        public async Task<ActionResult<Models.CartItem>> RemoveFromCart(int userId, int productId)
        {
            var item = await _db.CartItems
                                 .FirstOrDefaultAsync(ci => ci.UserId == userId && ci.ProductId == productId);

            if (item is null) return new NotFoundResult();

            _db.CartItems.Remove(item);
            await _db.SaveChangesAsync();
            return item;
        }

        public async Task<ActionResult> ClearCart(int userId)
        {
            var items = _db.CartItems.Where(ci => ci.UserId == userId);
            _db.CartItems.RemoveRange(items);
            await _db.SaveChangesAsync();
            return new OkResult();
        }

        public async Task<ActionResult<decimal>> Checkout(int userId)
        {
            var total = await _db.CartItems
                                  .Include(ci => ci.Product)
                                  .Where(ci => ci.UserId == userId)
                                  .SumAsync(ci => ci.Product.Price * ci.Quantity);

            await ClearCart(userId);
            return total;
        }
    }
}
