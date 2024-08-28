using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using Tunify_Platform.Models.DTO;

namespace Tunify_Platform.Repositories.Interfaces
{
    public interface IUser
    {
        //Add regester
        Task<UserDto> Register(RegisterUserDTO registerEmployeeDTO, ModelStateDictionary modelState);

        // Add Login 
        public Task<UserDto> LoginUser(string Username , string Password);

        public Task<UserDto> LogoutUser(string Username);

        // add user profile 
        public Task<UserDto> userProfile(ClaimsPrincipal claimsPrincipal);
    }
}
