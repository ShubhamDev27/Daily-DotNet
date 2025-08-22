using Microsoft.AspNetCore.Mvc;

namespace MiniProject.Service.User
{
    public interface IUser
    {
        Task<ActionResult<IEnumerable<Models.User>>> GetAllUsers();
        Task<ActionResult<Models.User>> GetUser(int id);
        Task<ActionResult<Models.User>> AddUser(Models.User user);
        Task<ActionResult<Models.User>> DeleteUser(int id);
    }
}
