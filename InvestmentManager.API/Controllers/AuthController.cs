using InvestmentManager.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly TokenService _tokenService;

        public AuthController(IUserService userService, TokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
        {
            var user = await _userService.GetUserByEmailAsync(loginDto.Email);

            if (user == null || !user.Password.Equals(loginDto.Password)) // Para fins de simplicidade
            {
                return Unauthorized("Email ou senha inválidos");
            }

            var token = _tokenService.GenerateToken(user.Email);
            return Ok(new { token });
        }
    }
}
