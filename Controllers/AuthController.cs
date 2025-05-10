using EventManagement.Server.Dtos.Auth;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace EventManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest loginDto)
        {
            // TODO Implement your login logic here
            return Ok();
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] SignupDto registerDto)
        {
            // TODO Implement your registration logic here
            return Ok();
        }
        
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            // TODO Implement your logout logic here
            return Ok();
        }
    }
}
