using AdminPanel.Abstractions.Data.Services;
using AdminPanel.Web.Models;

using Microsoft.AspNetCore.Mvc;

namespace AdminPanel.Web.Controllers
{
    [Route("account/{action}")]
    public class AccountController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public AccountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginPostModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _authenticationService.SignInAsync(
                model.Email,
                model.Password,
                model.IsPersistent);

            if (!result.Succeeded)
            {
                ViewBag.ErrorMessage = result.Message;

                return View(model);
            }

            return Redirect("/");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _authenticationService.SignOutAsync();

            return Redirect("/");
        }
    }
}
