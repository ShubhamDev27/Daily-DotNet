using Microsoft.AspNetCore.Mvc;

namespace MiniProject.Service.Category
{
    public interface ICategory
    {
        Task<ActionResult<IEnumerable<Models.Category>>> GetAllCategories();
        Task<ActionResult<Models.Category>> GetCategory(int id);
        Task<ActionResult<Models.Category>> AddCategory(Models.Category category);
        Task<ActionResult<Models.Category>> DeleteCategory(int id);
    }
}
