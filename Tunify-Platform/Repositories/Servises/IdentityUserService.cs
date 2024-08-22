﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Tunify_Platform.Models;
using Tunify_Platform.Models.DTO;
using Tunify_Platform.Repositories.Interfaces;

namespace Tunify_Platform.Repositories.Services
{
    public class IdentityUserService : IUser
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IdentityUserService(UserManager<ApplicationUser> userManager , SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

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
                return new UserDto
                {
                    Id = employee.Id,
                    UserName = employee.UserName,
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

        public async Task<UserDto> LoginUser(string Username, string Password)
        {
            var user = await _userManager.FindByNameAsync(Username);

            bool passValedation = await _userManager.CheckPasswordAsync(user, Password);

            if (passValedation)
            {
                return new UserDto()
                {
                    Id = user.Id,
                    UserName = user.Id,
                };
            }
            return null;
        }

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

    }
}
