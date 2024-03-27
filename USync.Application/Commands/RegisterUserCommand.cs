using Flunt.Notifications;
using Flunt.Validations;
using USync.Application.Commands.Contracts;

namespace USync.Application;

public class RegisterUserCommand : Notifiable<Notification>, ICommand
{
    public RegisterUserCommand()
    {

    }

    public RegisterUserCommand(string Login, string Password, string PasswordConfirmed, string Email)
    {
        
    }

    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string PasswordConfirmed { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public void Validate()
        {
            AddNotifications(new Contract<RegisterUserCommand>()
                .Requires()
                .IsNotNullOrEmpty(Login, "Login", "Login not Found!")
                .IsNotNullOrEmpty(Email, "Email", "Email not Found!")
                .IsNotNullOrEmpty(Password, "Password", "Password not Found!")
                .IsNotNullOrEmpty(PasswordConfirmed, "PasswordConfirmed", "PasswordConfirmed not Found!")
                .IsGreaterThan(Password.Length, 8, "Password", "Passord must have more than 8 characters")
                .IsGreaterThan(Password.Length, 8, "PasswordConfirmed", "The Confirmed Passord must have more than 8 characters")
                .IsEmail(Email, "Email", "The Email is not valid")
                .Matches(Password, PasswordConfirmed, "Passwords", "The Passwords must matches")
            );
        }
}
