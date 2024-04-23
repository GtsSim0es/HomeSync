using Microsoft.EntityFrameworkCore;
using USync.Application;
using USync.Domain.Entities;
using USync.Infrastructure.Data.ApplicationDB;

namespace USync.Infrastructure;

public class TasksRepository(ApplicationDbContext context) : ITasksRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<UserTask?> GetTasks(long taskId) => await _context.UserTasks.FirstOrDefaultAsync(x => x.Id == taskId);

    public async Task<IEnumerable<UserTask>> GetTasksList(User user) => await _context.UserTasks.Where(x => x.UserId == user.Id).ToListAsync();

    public async Task AddTask(UserTask newTask) => await _context.UserTasks.AddAsync(newTask);

    public void RemoveTask(UserTask Task) => _context.UserTasks.Remove(Task);

}
