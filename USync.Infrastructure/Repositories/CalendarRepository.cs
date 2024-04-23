using Microsoft.EntityFrameworkCore;
using USync.Application;
using USync.Domain.Entities;
using USync.Infrastructure.Data.ApplicationDB;

namespace USync.Infrastructure;

public class CalendarRepository(ApplicationDbContext context) : ICalendarRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<UserCalendar>> GetCalendarToList(User user) => await _context.UserCalendar.Where(x => x.UserId == user.Id).ToListAsync();
}
