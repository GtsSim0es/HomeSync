using Flunt.Notifications;
using Flunt.Validations;
using System.ComponentModel.DataAnnotations;
using USync.Application.Commands.Contracts;
using USync.Domain.Entities;

namespace USync.Application.Commands
{
    public class AuthenticateUserCommand : Notifiable<Notification>, ICommand
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        public void Validate()
        {
            AddNotifications(new Contract<User>()
                .Requires()
                .IsNotNullOrEmpty(Password, "Password", "Password not Found!")
                .IsGreaterThan(Password.Length, 8, "Password", "Passord must have more than 8 characters")
            );
        }
    }
}
