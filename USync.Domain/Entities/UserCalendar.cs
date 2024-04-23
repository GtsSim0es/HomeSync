using System.ComponentModel.DataAnnotations.Schema;
using USync.Domain.Common;

namespace USync.Domain.Entities;

public class UserCalendar(DateTime date, string description, Adress adress, User user) : Entity
{
    public DateTime Date { get; set; } = date;
    public string Description { get; set; } = description;
    public Adress Adress { get; set; } = adress;

    public long UserId { get; set; } = user.Id;
    [ForeignKey("UserId")]
    public User User { get; set; } = user;
    
    public List<Person> People { get; set; } = new List<Person>();
}
