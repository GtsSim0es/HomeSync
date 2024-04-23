using Microsoft.AspNetCore.Mvc;
using USync.Application.Commands;
using USync.Application.Handlers.Contracts;

namespace USync.WebApp.Controllers
{
    public class TasksController : Controller
    {
        public IActionResult Index() => View("Index");

        [HttpPost]
        public async Task<GenericCommandResult> CreateTask(
            TaskCreateCommand command,
            [FromServices] IHandler<TaskCreateCommand> handler
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
