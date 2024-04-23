using Microsoft.AspNetCore.Mvc;
using USync.Application;
using USync.Application.Commands;
using USync.Application.Handlers.Contracts;
using USync.Application.Interfaces;

namespace USync.WebApp.Controllers
{
    public class CalendarController : Controller
    {
        public async Task<IActionResult> Index(
            [FromServices] ICalendarRepository calendarRepository,
            [FromServices] IUsersRepository userRepository
            ) 
        {
            //TODO: remover instacia de repositorio de users
            var user = await userRepository.GetUserByLoginAsync("gabriel");
            var calendarEvents = calendarRepository.GetCalendarEventsToList(user);

            return View(calendarEvents);
        } 

        [HttpPost]
        public async Task<GenericCommandResult> CreateCalendarEvent(
            CalendarCreateEventCommand command,
            [FromServices] IHandler<CalendarCreateEventCommand> handler
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
