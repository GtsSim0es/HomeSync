using System.ComponentModel.DataAnnotations.Schema;
using USync.Domain.Common;

namespace USync.Domain.Entities;

public class UserTask(string name, string description, DateTime scheduleDate) : Entity
{
    public string Name { get; set; } = name;

    public string Description { get; set; } = description;
    
    public DateTime ScheduleDate { get; set; } = scheduleDate;

    public long UserId { get; set; }
    [ForeignKey("UserId")]
    public User User { get; set; }

    public List<Person> PeapleAsigned { get; set; } = new List<Person>();
}
