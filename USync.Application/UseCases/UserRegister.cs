using USync.Application.Interfaces;
using USync.Domain.Entities;

namespace USync.Application.UseCases
{
    public class UserRegister(IUsersRepository userRepository, IUnitOfWork unitOfWork)
    {
        private readonly IUsersRepository _userRepository = userRepository;
        private readonly IUnitOfWork uow = unitOfWork;

        public async Task Register(User user)
        {
            user.Validate();
            if (!user.IsValid)
                return;

            await _userRepository.CreateUserAsync(user);
            await uow.CommitAsync();
        }
    }
}
