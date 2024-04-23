using Flunt.Notifications;
using USync.Application.Commands;
using USync.Application.Commands.Contracts;
using USync.Application.Handlers.Contracts;
using USync.Application.Interfaces;
using USync.Domain.Entities;

namespace USync.Application.Handlers
{
    public class UserHandler(IUsersRepository userRepository, IUnitOfWork unitOfWork) :
        Notifiable<Notification>,
        IHandler<AuthenticateUserCommand>
    {
        private readonly IUsersRepository _userRepository = userRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<ICommandResult> HandleAsync(AuthenticateUserCommand command)
        {
            command.Validate();
            if (!command.IsValid)
                return new GenericCommandResult(false, "Ops, your handle method is wrong!", command.Notifications);

            var foundedUser = await _userRepository.GetUserByLoginAsync(command.Username);
            foundedUser.Validate();
            foundedUser.ValidatePassword(command.Password);
 
            if(!foundedUser.IsValid)
                return new GenericCommandResult(false, "Ops, the user founded in our database has an error!", foundedUser.Notifications);

            return new GenericCommandResult(true, "The user can be Authenticated", command.Username);
        }

        public async Task<ICommandResult> HandleAsync( RegisterUserCommand command)
        {
            command.Validate();
            if (!command.IsValid)
                return new GenericCommandResult(false, "Ops, your handle method is wrong!", command.Notifications);

            var newUser = new User(command.Login, command.Password);
            await _userRepository.CreateUserAsync(newUser);
            
            await _unitOfWork.CommitAsync();

            if(!newUser.IsValid)
                return new GenericCommandResult(false, "Ops, the user has an error on register!", newUser.Notifications);
 
            return new GenericCommandResult(true, "The User was created", newUser);
        }
    }
}