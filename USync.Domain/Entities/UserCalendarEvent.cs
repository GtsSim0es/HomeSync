using System.ComponentModel.DataAnnotations.Schema;
using Flunt.Validations;
using USync.Domain.Common;

namespace USync.Domain.Entities;

public class UserCalendarEvent(DateTime date, string name, string description, long userId) : Entity
{
    public DateTime Date { get; set; } = date;

    public string Name { get; set; } = name;

    public string Description { get; set; } = description;

    public long? AdressId { get; set; }
    [ForeignKey("AdressId")]
    public Adress? Adress { get; set; }

    public long UserId { get; set; } = userId;
    [ForeignKey("UserId")]
    public User? User { get; set; }

    public List<Person> People { get; set; } = new List<Person>();

    public void Validate()
    {
        AddNotifications(new Contract<UserCalendarEvent>()
        .Requires()
        .IsGreaterThan(base.Id, 0, "Id", "Event not found!")
        .IsNotNullOrEmpty(Name, "Name", "Name not found!")
        .IsNotNullOrEmpty(Description, "Description", "Description not Found!")
        .IsGreaterThan(Date, DateTime.MinValue, "Date", "Date is not valid!")
        );
    }
}
