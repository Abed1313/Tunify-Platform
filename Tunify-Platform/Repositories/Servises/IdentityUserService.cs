using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using Tunify_Platform.Models;
using Tunify_Platform.Models.DTO;
using Tunify_Platform.Repositories.Interfaces;
using Tunify_Platform.Repositories.Servises;

namespace Tunify_Platform.Repositories.Services
{
    public class IdentityUserService : IUser
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        //Inject JWT Serveses
        private JwtTokenServeses JwtTokenServeses;
        //constructor
        public IdentityUserService(UserManager<ApplicationUser> userManager,
                           SignInManager<ApplicationUser> signInManager,
                           JwtTokenServeses jwtTokenServeses)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            JwtTokenServeses = jwtTokenServeses ?? throw new ArgumentNullException(nameof(jwtTokenServeses));
        }
        // Register
        public async Task<UserDto> Register(RegisterUserDTO registerEmployeeDTO, ModelStateDictionary modelState)
        {
            var employee = new ApplicationUser
            {
                UserName = registerEmployeeDTO.UserName,
                Email = registerEmployeeDTO.Email,
            };

            var result = await _userManager.CreateAsync(employee, registerEmployeeDTO.Password);
            if (result.Succeeded)
            {
                // add Roles to the new rigstred user
                await _userManager.AddToRolesAsync(employee, registerEmployeeDTO.Roles);
                return new UserDto
                {
                    Id = employee.Id,
                    UserName = employee.UserName,
                    Roles = await _userManager.GetRolesAsync(employee)
                };
            }

            foreach (var error in result.Errors)
            {
                var errorCode = error.Code.Contains("Password") ? nameof(registerEmployeeDTO.Password) :
                                error.Code.Contains("Email") ? nameof(registerEmployeeDTO.Email) :
                                error.Code.Contains("UserName") ? nameof(registerEmployeeDTO.UserName) : "UnknownError";

                modelState.AddModelError(errorCode, error.Description);
            }
            return null;
        }
        // Login
        public async Task<UserDto> LoginUser(string Username, string Password)
        {
            var user = await _userManager.FindByNameAsync(Username);
            if (user == null)
            {
                return null; // or return a custom error indicating user not found
            }

            bool passValidation = await _userManager.CheckPasswordAsync(user, Password);
            if (passValidation)
            {
                return new UserDto()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Token = await JwtTokenServeses.GenerateToken(user, TimeSpan.FromDays(14))
                };
            }
            return null;
        }

        // Logout
        public async Task<UserDto> LogoutUser(string Username)
        {
            var user = await _userManager.FindByNameAsync(Username);
            if (user == null)
            {
                return null;
            }
            
            await _signInManager.SignOutAsync();
            var result = new UserDto()
            {
                Id = user.Id,
                UserName = user.UserName
            };
            return result;
        }

        public async Task<UserDto> userProfile(ClaimsPrincipal claimsPrincipal)
        {
           var user = await _userManager.GetUserAsync(claimsPrincipal);

            return new UserDto()
            {
                Id = user.Id,
                UserName = user.UserName,
                Token = await JwtTokenServeses.GenerateToken(user, System.TimeSpan.FromDays(14))
            };


        }
    }
}
