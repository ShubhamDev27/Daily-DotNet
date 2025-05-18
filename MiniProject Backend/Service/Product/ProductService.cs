using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniProject.Repository;

namespace MiniProject.Service.Product
{
    public class ProductService : IProduct
    {
        private readonly AppDbContext _db;
        public ProductService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<ActionResult<IEnumerable<Models.Product>>> GetAllProducts()
        {
            var prod = await _db.Products.Include(p => p.Category).ToListAsync();
            return prod;
        }

        public async Task<ActionResult<IEnumerable<Models.Product>>> GetProductsByCategory(string name)
        {
            var prod = await _db.Products.Include(p => p.Category)
                                         .Where(p => p.Category.Name == name)
                                         .ToListAsync();
            return prod;
        }

        public async Task<ActionResult<Models.Product>> GetProduct(int id)
        {
            var prod = await _db.Products.Include(p => p.Category)
                                          .FirstOrDefaultAsync(p => p.Id == id);
            return prod is null ? new NotFoundResult() : prod;
        }

        public async Task<ActionResult<Models.Product>> AddProduct(Models.Product product)
        {
            _db.Products.Add(product);
            await _db.SaveChangesAsync();
            return product;
        }

        public async Task<ActionResult<Models.Product>> DeleteProduct(int id)
        {
            var prod = await _db.Products.FindAsync(id);
            if (prod is null) return new NotFoundResult();
            _db.Products.Remove(prod);
            await _db.SaveChangesAsync();
            return prod;
        }
    }
}