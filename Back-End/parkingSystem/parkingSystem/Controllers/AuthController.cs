using BLL;
using Microsoft.AspNetCore.Mvc;
using Models;


namespace ParkingSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            try
            {
                var registeredUser = await _authService.RegisterAsync(user);
                return Ok(registeredUser);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            var loggedUser = await _authService.LoginAsync(user.Email, user.Password);
            if (loggedUser == null)
                return Unauthorized(new { message = "Invalid email or password" });

            return Ok(loggedUser);
        }
    }
}
