using USync.Domain.Entities;

namespace USync.Application;

public interface ITasksRepository
{
    Task<IEnumerable<UserTask>> GetTasksList(User user);
    Task<UserTask?> GetTasks(long taskId);
    Task AddTask(UserTask newTask);
    void RemoveTask(UserTask Task);
}
