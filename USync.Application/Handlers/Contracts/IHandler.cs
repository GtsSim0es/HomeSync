using USync.Application.Commands.Contracts;

namespace USync.Application.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}