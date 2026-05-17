using JobTrackerAPI.DTOs;
using JobTrackerAPI.Helpers;
using JobTrackerAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JobTrackerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            this._authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var result = await _authService.RegisterAsync(dto);
            return Ok(new ApiResponse<string>(true, result));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var token = await _authService.LoginAsync(dto);

            if (token == null)
                return Unauthorized(new ApiResponse<object>(false, "Invalid credentials"));

            return Ok(new ApiResponse<object>(true, "Login successful", new { Token = token }));
        }
    }
}
