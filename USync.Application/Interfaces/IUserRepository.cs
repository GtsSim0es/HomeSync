using USync.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USync.Application.Interfaces
{
    public interface IUserRepository
    {
        void UpdateUser(User user);

        void DeleteUser(User user);

        Task<List<User>> GetUsersListAsync(List<long> ids);

        Task<User> GetUserAsync(long id);

        Task<User> GetUserByLoginAsync(string login);

        Task CreateUserAsync(User user);
    }
}
