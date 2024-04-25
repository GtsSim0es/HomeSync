using USync.Domain.Entities;

namespace USync.Application;

public interface ICalendarRepository
{
    Task<IEnumerable<UserCalendarEvent>> GetCalendarEventsToList(User user);
    Task<UserCalendarEvent> GetCalendarEvent(long eventId);
    Task AddCalendarEvent(UserCalendarEvent newEvent);
    void RemoveCalendarEvent(UserCalendarEvent eventToRemove);
}
