using Microsoft.EntityFrameworkCore;
using USync.Application;
using USync.Domain.Entities;
using USync.Infrastructure.Data.ApplicationDB;

namespace USync.Infrastructure;

public class TasksRepository(ApplicationDbContext context) : ITasksRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<UserTask>> GetTasksList(User user) => await _context.UserTasks.Where(x => x.UserId == user.Id).ToListAsync();
}
