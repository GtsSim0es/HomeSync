using System.ComponentModel.DataAnnotations.Schema;
using USync.Domain.Common;

namespace USync.Domain.Entities;

public class UserTask(string description, DateTime scheduleDate, User user) : Entity
{
    public string Description { get; set; } = description;
    
    public DateTime ScheduleDate { get; set; } = scheduleDate;

    public long UserId { get; set; } = user.Id;
    [ForeignKey("UserId")]
    public User User { get; set; } = user;

    public List<Person> PeapleAsigned { get; set; } = new List<Person>();
}
