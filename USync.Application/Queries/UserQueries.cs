using System.Linq.Expressions;
using USync.Domain.Entities;

namespace USync.Application.Queries
{
    public static class UserQueries
    {
        public static Expression<Func<User, bool>> GetUserByLogin(string login)
        {
            return x => x.Login == login;
        }
    }
}
