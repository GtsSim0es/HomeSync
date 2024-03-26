using Flunt.Notifications;
using USync.Application.Commands;
using USync.Application.Commands.Contracts;
using USync.Application.Handlers.Contracts;
using USync.Application.Interfaces;

namespace USync.Application.Handlers
{
    public class UserHandler(IUserRepository userRepository) :
        Notifiable<Notification>,
        IHandler<AuthenticateUserCommand>
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<ICommandResult> HandleAsync(AuthenticateUserCommand command)
        {
            command.Validate();
            if (!command.IsValid)
                return new GenericCommandResult(false, "Ops, your handle method is wrong!", command.Notifications);

            var foundedUser = await _userRepository.GetUserByLoginAsync(command.Username);
            foundedUser.Validate();
            foundedUser.ValidatePassword(command.Password);

            if(!foundedUser.IsValid)
                return new GenericCommandResult(false, "Ops, your founded user has an error!", foundedUser.Notifications);

            return new GenericCommandResult(true, "The user can be Authenticated", command.Username);
        }
    }
}