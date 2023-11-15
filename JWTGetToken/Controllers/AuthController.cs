using JWTGetToken.Models;
using JWTGetToken.Services;
using JWTtoken.Services.Security;
using Microsoft.AspNetCore.Mvc;

namespace JWTGetToken.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly ITokenService tokenService;

        public AuthController(IUserService userService, ITokenService tokenService)
        {
            this.userService = userService;
            this.tokenService = tokenService;
        }

        [HttpPost]
        public async ValueTask<IActionResult> Login(LoginRequest loginRequest)
        {
            var result = await userService.GetAllUsers();
            var user = result.FirstOrDefault(x => x.UserName == loginRequest.Username && x.PasswordHash == Hash512.ComputeHash512(loginRequest.Password));
            if (user != null) 
            {
                string token = tokenService.GenerateToken(loginRequest.Username);
                return Ok(token);
            }
            return BadRequest();
        }
    }
}
