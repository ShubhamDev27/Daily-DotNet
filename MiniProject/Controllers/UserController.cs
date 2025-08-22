using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MiniProject.DTOs;
using MiniProject.Models;
using MiniProject.Repository;
using MiniProject.Service.User;

namespace MiniProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUser _service;
        private readonly AppDbContext _dbContext;
        private readonly IConfiguration _config;   // 👈 add

        public UsersController(IUser service, AppDbContext dbContext, IConfiguration config)
        {
            _service = service;
            _dbContext = dbContext;
            _config = config;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _service.GetAllUsers();
            return result.Result ?? Ok(result.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var result = await _service.GetUser(id);
            return result.Result ?? Ok(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            var result = await _service.AddUser(user);
            return result.Result ?? CreatedAtAction(nameof(GetUser),
                                                    new { id = ((dynamic)result.Value).Id },
                                                    result.Value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _service.DeleteUser(id);
            return result.Result ?? Ok(result.Value);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            var user = _dbContext.Users
                        .SingleOrDefault(u => u.Username == loginDto.Username);

            if (user is null || user.Password != loginDto.Password)
                return Unauthorized("Invalid username or password");

            var token = GenerateJwtToken(user);
            return Ok(new { token });
        }
        private string GenerateJwtToken(User user)
        {
            var claims = new List<Claim>
{
    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
    new Claim(JwtRegisteredClaimNames.UniqueName, user.Username),
    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
};

            var key = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.UtcNow
                          .AddMinutes(Convert.ToDouble(_config["Jwt:ExpiresInMinutes"] ?? "60"));

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: expires,
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }



    }
}
