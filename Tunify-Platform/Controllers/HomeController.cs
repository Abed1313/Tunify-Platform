using Microsoft.AspNetCore.Mvc;
using Tunify_Platform.Models.DTO;
using Tunify_Platform.Repositories.Interfaces;

namespace Tunify_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IUser _userManager;

        public HomeController(IUser userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterUserDTO registerEmployeeDTO)
        {
            var employee = await _userManager.Register(registerEmployeeDTO, this.ModelState);
            if (ModelState.IsValid)
            {
                return Ok(employee);
            }
            return BadRequest(ModelState);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.LoginUser(loginDto.Username, loginDto.Password);

            if (user == null)
            {
                return Unauthorized();
            }
            return user;
        }
        [HttpPost("Logout")]
        public async Task<UserDto> Logout(string Username)
        {
           var user =  await _userManager.LogoutUser(Username);
            return user;
        }
    }
}
