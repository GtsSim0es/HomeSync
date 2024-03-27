using Flunt.Validations;

namespace USync.Application.Commands.Contracts
{
    public interface ICommand
    {
        void Validate();
    }
}