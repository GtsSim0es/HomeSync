using HomeSync.Application.Interfaces;
using HomeSync.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeSync.Application.UseCases
{
    public class UserLogon(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IUnitOfWork uow = unitOfWork;

        public async Task Authenticate(User user, string userPassword)
        {
            user.Validate();
            user.ValidatePassword(userPassword);
            if (!user.IsValid)
                return;

            await _userRepository.CreateUserAsync(user);
            await uow.CommitAsync();
        }
    }
}
