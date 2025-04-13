using Microsoft.AspNetCore.Mvc;
using CRUD_API.Models;
using CRUD_API.Services;

namespace YourProjectName.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDto request)
        {
            var result = await _authService.Register(request);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserDto request)
        {
            var user = await _authService.Authenticate(request);
            if (user == null)
                return Unauthorized("Invalid username or password");

            // JWT will be returned here later
            return Ok("Login successful — JWT token will be generated next.");
        }
    }
}
