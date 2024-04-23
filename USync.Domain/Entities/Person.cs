using USync.Domain.Common;

namespace USync.Domain.Entities
{
    public class Person(string name, string email, string phone, string zipCode) : Entity
    {
        public string Name { get; set; } = name;
        public string Email { get; set; } = email;
        public string Phone { get; set; } = phone;
        public string ZipCode { get; set; } = zipCode;
    }
}
