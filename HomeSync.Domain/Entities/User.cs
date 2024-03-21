using HomeSync.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeSync.Domain.Entities
{
    public class User(long id, string login, string password, long profileId) : Entity(id)
    {
        public string Login { get; private set; } = login;

        public string Password { get; private set; } = password;

        public long ProfileId { get; set; } = profileId;
        [ForeignKey("ProfileId")]
        public Profile? Profile { get; set; }

        public bool ValidatePassword(string passwordToValidate)
        {
            return Password == passwordToValidate;
        }
    }
}
