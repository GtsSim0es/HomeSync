using HomeSync.Application.Interfaces;
using HomeSync.Domain.Entities;

namespace HomeSync.Application.UseCases
{
    public class UserRegister(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IUnitOfWork uow = unitOfWork;

        public async Task Register(User user)
        {
            user.Validate();
            if (!user.IsValid)
                return;

            await _userRepository.CreateUserAsync(user);
            uow.Commit();
        }
    }
}
