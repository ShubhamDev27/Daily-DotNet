using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniProject.Repository;
using MiniProject.Models;

namespace MiniProject.Service.Category
{
    public class CategoryService : ICategory
    {
        private readonly AppDbContext _db;
        public CategoryService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<ActionResult<IEnumerable<Models.Category>>> GetAllCategories()
        {
            var cat = await _db.Categories.Include(c=>c.Products).ToListAsync();
            return cat;
        }

        public async Task<ActionResult<Models.Category>> GetCategory(int id)
        {
            var cat = await _db.Categories.FindAsync(id);
            return cat is null ? new NotFoundResult() : cat;
        }

        public async Task<ActionResult<Models.Category>> AddCategory(Models.Category category)
        {
            _db.Categories.Add(category);
            await _db.SaveChangesAsync();
            return category;
        }

        public async Task<ActionResult<Models.Category>> DeleteCategory(int id)
        {
            var cat = await _db.Categories.FindAsync(id);
            if (cat is null) return new NotFoundResult();
            _db.Categories.Remove(cat);
            await _db.SaveChangesAsync();
            return cat;
        }
    }
}