using System.ComponentModel.DataAnnotations;
using Flunt.Notifications;
using Flunt.Validations;
using USync.Application.Commands.Contracts;
using USync.Domain.Entities;

namespace USync.Application;

public class CalendarRemoveEventCommand : Notifiable<Notification>, ICommand
{
    [Required]
    public long Id { get; set; } = 0;

    public void Validate()
    {
        AddNotifications(new Contract<UserCalendarEvent>()
            .Requires()
            .IsGreaterThan(Id, 0, "Id", "Id must be greater than 0")
        );
    }
}
