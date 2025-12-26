using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login()
        {
            // Implementation for user login
            return Ok("Login successful");
        }

        [HttpPost]
        public IActionResult Register()
        {
            // Implementation for user registration
            return Ok("Registration successful");
        }
    }
}
