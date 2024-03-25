using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeSync.WebApp.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public IActionResult UnauthorizedUser()
        {
            return View();
        }

        [HttpPost]
        public string CreateUser()
        {
            return "";
        }
    }
}
