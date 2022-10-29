using AdminPanel.Abstractions.Core;

namespace AdminPanel.Abstractions.Data.Services
{
    public interface IAuthenticationService
    {
        Task<Result> SignInAsync(string email, string password, bool isPersistent);

        Task SignOutAsync();
    }
}