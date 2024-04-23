using Flunt.Notifications;
using Flunt.Validations;
using System.ComponentModel.DataAnnotations;
using USync.Application.Commands.Contracts;
using USync.Domain.Entities;

namespace USync.Application.Commands
{
    public class TaskCreateCommand : Notifiable<Notification>, ICommand
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Required]
        public DateTime ScheduleDate { get; set; } = DateTime.Now.Date;

        public void Validate()
        {
            AddNotifications(new Contract<User>()
                .Requires()
                .IsNotNullOrEmpty(Name, "Name", "Name not Found!")
                .IsGreaterOrEqualsThan(ScheduleDate, DateTime.Now.Date, "ScheduleDate", "ScheduleDate cannot be lower than today!")
            );
        }
    }
}
