using ecommerce.Data;
using ecommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly EcommerceDataContext _context;

        public RoleController(EcommerceDataContext context)
        {
            _context = context;
        }

        [HttpGet]

        public IActionResult GetRoles()
        {
            var roles = _context.Roles.ToList();
            return Ok(roles);
        }


        [HttpPost]

        public IActionResult Create([FromBody] Role role)
        {
            if (role == null)
            {
                return BadRequest("Role is null.");
            }

            Role roleToUpdate = new Role
            {
                RoleName = role.RoleName,
               
            };
             _context.Roles.Add(roleToUpdate);
            _context.SaveChanges();
            return Ok("yes");
        }

    }
}
