using Flunt.Notifications;
using USync.Application.Commands;
using USync.Application.Commands.Contracts;
using USync.Application.Handlers.Contracts;

namespace USync.Application.Handlers
{
    public class UserHandler :
        Notifiable<Notification>,
        IHandler<AuthenticateUserCommand>
    {
        public ICommandResult Handle(AuthenticateUserCommand command)
        {
            command.Validate();
            if (!command.IsValid)
                return new GenericCommandResult(false,
                                                "Ops, parece que sua tarefa está errada!",
                                                command.Notifications);

            return new GenericCommandResult(true, "Tarefa salva", command.Username);
        }
    }
}