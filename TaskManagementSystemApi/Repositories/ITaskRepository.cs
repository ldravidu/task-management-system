using TaskManagementSystemApi.Models;

namespace TaskManagementSystemApi.Repositories
{
    public interface ITaskRepository : IRepository<Models.Task>
    {
        Task<IEnumerable<Models.Task>> GetTasksWithDetails();
        Task<Models.Task?> GetTaskWithDetails(long id);
        Task<IEnumerable<Models.Task>> GetTasksByUserId(long userId);
        Task<IEnumerable<Models.Task>> GetTasksByProjectId(long projectId);
    }
}