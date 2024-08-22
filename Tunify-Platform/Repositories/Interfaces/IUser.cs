using Microsoft.AspNetCore.Mvc.ModelBinding;
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
    }
}
