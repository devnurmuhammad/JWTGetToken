using JWTGetToken.DTOs;
using JWTGetToken.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTGetToken.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(UserDTO userDTO)
        {
            await _userService.CreateUser(userDTO);
            return Ok("Created");
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        public async ValueTask<IActionResult> GetAllUser()
        {
            var result = await _userService.GetAllUsers();
            return Ok(result);
        }
    }
}
