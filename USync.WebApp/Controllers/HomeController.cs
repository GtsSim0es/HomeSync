using USync.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using USync.Application;
using USync.Infrastructure;
using USync.Application.Interfaces;

namespace USync.WebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUsersRepository _usersRepository;
        private readonly ICalendarRepository _calendarRepository;

        public HomeController(ILogger<HomeController> logger, 
                              ICalendarRepository calendarRepository, 
                              IUsersRepository usersRepository)
        {
            _logger = logger;
            _calendarRepository = calendarRepository;
            _usersRepository = usersRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Calendar()
        {
            var currentUser = await _usersRepository.GetUserAsync(1);
            var calendarList = await _calendarRepository.GetCalendarEventsToList(currentUser);

            return View(calendarList);
        }
    }
}
