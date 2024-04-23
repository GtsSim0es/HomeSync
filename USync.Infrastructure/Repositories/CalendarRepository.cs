using Microsoft.EntityFrameworkCore;
using USync.Application;
using USync.Domain.Entities;
using USync.Infrastructure.Data.ApplicationDB;

namespace USync.Infrastructure;

public class CalendarRepository(ApplicationDbContext context) : ICalendarRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task AddCalendarEvent(UserCalendarEvent newEvent) => await _context.UserCalendar.AddAsync(newEvent);

    public async Task<UserCalendarEvent?> GetCalendarEvent(long eventId) => await _context.UserCalendar.FirstOrDefaultAsync(x => x.Id == eventId);

    public async Task<IEnumerable<UserCalendarEvent>> GetCalendarEventsToList(User user) => await _context.UserCalendar.Where(x => x.UserId == user.Id).ToListAsync();

    public void RemoveCalendarEvent(UserCalendarEvent eventToRemove) => _context.UserCalendar.Remove(eventToRemove);
}
