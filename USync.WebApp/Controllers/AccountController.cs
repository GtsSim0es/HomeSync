using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using USync.Application.Commands;
using USync.Application.Handlers;

namespace USync.WebApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login() => View("Index");

        [HttpPost]
        public async Task<GenericCommandResult> Authenticate(
            AuthenticateUserCommand command,
            [FromServices] UserHandler handler
            )
        {
            if (!ModelState.IsValid)
                return new GenericCommandResult(false, "The Model Is invalid", new object());

            var result = (GenericCommandResult)await handler.HandleAsync(command);
            if (result.Success == false)
                return result;

            await AssignAuthenticatedCookieTokenToUser(command);

            return result;
        }
        private async Task AssignAuthenticatedCookieTokenToUser(AuthenticateUserCommand command)
        {
            var claims = new List<Claim>
                {
                    new(ClaimTypes.Name, command.Username)
                };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }

        [HttpPost]
        public string CreateUser()
        {
            return "";
        }
    }
}
