using Flunt.Validations;
using USync.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace USync.Domain.Entities
{
    public class User(long id, string login, string password, long profileId) : Entity(id)
    {
        public string Login { get; private set; } = login;

        public string Password { get; private set; } = password;

        public long ProfileId { get; set; } = profileId;
        [ForeignKey("ProfileId")]
        public Profile? Profile { get; set; }

        public void ValidatePassword(string passwordToValidate)
        {
            AddNotifications(new Contract<User>()
                .Requires()
                .IsTrue(Password == passwordToValidate, "Password", "The Password doesn't matche to the database!")
            );
        }

        public void Validate()
        {
            AddNotifications(new Contract<User>()
                .Requires()
                .IsNotNullOrEmpty(Login, "Login", "Login not found!")
                .IsNotNullOrEmpty(Password, "Password", "Password not Found!")
                .IsGreaterThan(Password.Length, 8, "Password", "Passord must have more than 8 characters")
                .IsLowerOrEqualsThan(ProfileId, 0, "Profile", "Invalid Profile, Must be greater than 0")
            );
        }
    }
}
