using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniProject.Repository;

namespace MiniProject.Service.User
{
    public class UserService : IUser
    {
        private readonly AppDbContext _db;
        public UserService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<ActionResult<IEnumerable<Models.User>>> GetAllUsers()
        {
            var user = await _db.Users.ToListAsync();
            return user;
        }

        public async Task<ActionResult<Models.User>> GetUser(int id)
        {
            var user = await _db.Users.FindAsync(id);
            return user is null ? new NotFoundResult() : user;
        }

        public async Task<ActionResult<Models.User>> AddUser(Models.User user)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return user;
        }

        public async Task<ActionResult<Models.User>> DeleteUser(int id)
        {
            var user = await _db.Users.FindAsync(id);
            if (user is null) return new NotFoundResult();
            _db.Users.Remove(user);
            await _db.SaveChangesAsync();
            return user;
        }
    }
}
