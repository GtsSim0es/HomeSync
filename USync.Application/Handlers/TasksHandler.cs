using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USync.Application.Commands.Contracts;
using USync.Application.Commands;
using USync.Application.Handlers.Contracts;
using USync.Application.Interfaces;
using USync.Domain.Entities;

namespace USync.Application.Handlers
{
    public class TasksHandler :
        Notifiable<Notification>,
        IHandler<TaskCreateCommand>
    {
        private readonly ITasksRepository _taskRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TasksHandler(IUnitOfWork unitOfWork, ITasksRepository taskRepository)
        {
            _taskRepository = taskRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ICommandResult> HandleAsync(TaskCreateCommand command)
        {
            command.Validate();
            if (!command.IsValid)
                return new GenericCommandResult(false, "Ops, your handle method is wrong!", command.Notifications);

            var calendarEvent = new UserTask(command.Name, command.Description, command.ScheduleDate);
            await _taskRepository.AddTask(calendarEvent);

            await _unitOfWork.CommitAsync();

            if (!calendarEvent.IsValid)
                return new GenericCommandResult(false, "Ops, the event has an error on register!", calendarEvent.Notifications);

            return new GenericCommandResult(true, "The Event was created", calendarEvent);
        }
    }
}
