using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USync.Application.Commands;
using USync.Application.Commands.Contracts;
using USync.Application.Handlers.Contracts;
using USync.Application.Interfaces;
using USync.Domain.Entities;

namespace USync.Application.Handlers
{
    public class CalendarEventHandler :
        Notifiable<Notification>,
        IHandler<CalendarCreateEventCommand>
        IHandler<CalendarRemoveEventCommand>
    {
        private readonly ICalendarRepository _calendarRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CalendarEventHandler(IUnitOfWork unitOfWork, ICalendarRepository calendarRepository)
        {
            _calendarRepository = calendarRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ICommandResult> HandleAsync(CalendarCreateEventCommand command)
        {
            command.Validate();
            if (!command.IsValid)
                return new GenericCommandResult(false, "Ops, your handle method is wrong!", command.Notifications);

            var calendarEvent = new UserCalendarEvent(command.DateOfEvent, command.Name, command.Description, 1);
            await _calendarRepository.AddCalendarEvent(calendarEvent);

            await _unitOfWork.CommitAsync();

            if (!calendarEvent.IsValid)
                return new GenericCommandResult(false, "Ops, the event has an error on register!", calendarEvent.Notifications);

            return new GenericCommandResult(true, "The Event was created", calendarEvent);
        }

        public async Task<ICommandResult> HandleAsync(CalendarRemoveEventCommand command)
        {
            command.Validate();
            if (!command.IsValid)
                return new GenericCommandResult(false, "Ops, your handle method is wrong!", command.Notifications);

            var calendarEvent = await _calendarRepository.GetCalendarEvent(command.Id);
            
            calendarEvent.Validate();
            if (!calendarEvent.IsValid)
                return new GenericCommandResult(false, "Ops, the event has an error on register!", calendarEvent.Notifications);

            return new GenericCommandResult(true, "The Event was found", calendarEvent);
        }
    }
}
