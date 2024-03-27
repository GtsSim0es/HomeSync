using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using USync.Application;
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
            try
            {
                if (!ModelState.IsValid)
                    return new GenericCommandResult(false, "The Model Is invalid", new object());

                var result = (GenericCommandResult)await handler.HandleAsync(command);
                if (result.Success)
                    await AssignAuthenticatedCookieTokenToUser(command);

                return result;
            }
            catch (Exception ex)
            {
                return new GenericCommandResult(false, $"Opss, We have an error here: {ex.Message}", new object());
            }
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
        public async Task<GenericCommandResult> CreateUser(
            RegisterUserCommand command,
            [FromServices] UserHandler handler
        )
        {
            try
            {
                if (!ModelState.IsValid)
                    return new GenericCommandResult(false, "The Model Is invalid", new object());

                var result = (GenericCommandResult)await handler.HandleAsync(command);

                return result;
            }
            catch (Exception ex)
            {
                return new GenericCommandResult(false, $"Opss, We have an error here: {ex.Message}", new object());
            }
        }
    }
}
