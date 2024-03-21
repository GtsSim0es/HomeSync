using HomeSync.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeSync.Domain.Entities
{
    public class User(long id, string login, string password, Profile profile) : Entity(id)
    {
        public string Login { get; private set; } = login;

        private readonly string Password = password;

        public Profile Profile { get; private set; } = profile;

        public bool ValidatePassword(string passwordToValidate)
        {
            return Password == passwordToValidate;
        }
    }
}
