using AdminPanel.Abstractions.Core;
using AdminPanel.Abstractions.Core.Results;
using AdminPanel.Abstractions.Data.Services;
using AdminPanel.Data.Models;

using Microsoft.AspNetCore.Identity;

namespace AdminPanel.Data.Services
{
    internal class AuthenticationService : IAuthenticationService
    {
        private readonly SignInManager<AppUser> _signInManager;

        public AuthenticationService(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<Result> SignInAsync(string email, string password, bool isPersistent)
        {
            var result = await _signInManager.PasswordSignInAsync(
                email,
                password,
                isPersistent,
                true);

            if (result.IsNotAllowed)
            {
                return ResultFactory.Failure("Login not allowed");
            }

            if (result.IsLockedOut)
            {
                return ResultFactory.Failure("Account locked out");
            }

            return ResultFactory.Success();
        }

        public async Task SignOutAsync() =>
            await _signInManager.SignOutAsync();
    }
}
