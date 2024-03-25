using USync.Application.Interfaces;
using USync.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USync.Application.UseCases
{
    public class UserLogon(IUserRepository userRepository)
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<bool> VerifyCredentialsOfUser(string login, string userPassword)
        {
            var user = await _userRepository.GetUserByLoginAsync(login);

            user.Validate();
            user.ValidatePassword(userPassword);
            if (!user.IsValid)
                return true;

            return false;
        }
    }
}
