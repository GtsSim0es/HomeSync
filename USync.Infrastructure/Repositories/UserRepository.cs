using USync.Application.Interfaces;
using USync.Domain.Entities;
using USync.Infrastructure.Data.ApplicationDB;
using Microsoft.EntityFrameworkCore;

namespace USync.Infrastructure.Repositories
{
    internal class UserRepository(ApplicationDbContext context) : IUserRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task CreateUserAsync(User user) => await _context.Users.AddAsync(user);

        public void DeleteUser(User user) => _context.Users.Remove(user);

        public void UpdateUser(User user) => _context.Users.Update(user);

        public async Task<User> GetUserAsync(long id) => await _context.Users.FirstAsync(x => x.Id == id);

        public async Task<List<User>> GetUsersListAsync(List<long> ids)
        {
            var query = _context.Users.AsQueryable();

            if (ids.Count > 0)
                query.Where(x => ids.Contains(x.Id));

            return await query.ToListAsync();
        }
    }
}
