using ecommerce.Data;
using ecommerce.DTO;
using ecommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {  private readonly EcommerceDataContext _dbContext;
        public AuthController(EcommerceDataContext dataContext)
        {
            _dbContext = dataContext;
        }

        [HttpPost("Login")]
        public IActionResult Login()
        {
            // Implementation for user login
            return Ok("Login successful");
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO dto)
        {   if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (dto == null)
            {
                return BadRequest("Invalid registration data");
            }
            var hashPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);
            var validatRoleIds= await _dbContext.Roles
                .Where(r => dto.RoleIds.Contains(r.RoleId))
                .Select(r => r.RoleId)
                .ToListAsync();

            if(validatRoleIds.Count != dto.RoleIds.Count)
            {
                return BadRequest("One of the role is is invalid.");
            }
            User userToCreate =new User
            {
                UserEmail = dto.UserEmail,
                Username = dto.Username,
                Password = hashPassword,
                UserRoles = validatRoleIds.Select(RoleId => new UserRole
                {
                    RoleId = RoleId
                }).ToList(),

            };

            await _dbContext.Users.AddAsync(userToCreate);
            await _dbContext.SaveChangesAsync();
             return Ok("User registered successfully");

        }
    }
}
