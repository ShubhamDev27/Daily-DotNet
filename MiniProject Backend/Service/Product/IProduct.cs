using Microsoft.AspNetCore.Mvc;

namespace MiniProject.Service.Product
{
    public interface IProduct
    {
        Task<ActionResult<IEnumerable<Models.Product>>> GetAllProducts();
        Task<ActionResult<IEnumerable<Models.Product>>> GetProductsByCategory(string name);
        Task<ActionResult<Models.Product>> GetProduct(int id);
        Task<ActionResult<Models.Product>> AddProduct(Models.Product product);
        Task<ActionResult<Models.Product>> DeleteProduct(int id);
    }
}
