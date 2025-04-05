using Microsoft.EntityFrameworkCore;
using TaskManagementSystemApi.Data;
using TaskManagementSystemApi.Models;

namespace TaskManagementSystemApi.Repositories
{
    public class TaskRepository : Repository<Models.Task>, ITaskRepository
    {
        public TaskRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Models.Task>> GetTasksWithDetails()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<Models.Task?> GetTaskWithDetails(long id)
        {
            return await _context.Tasks
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Models.Task>> GetTasksByUserId(long userId)
        {
            return await _context.Tasks
                .Where(t => t.AssignedToId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Models.Task>> GetTasksByProjectId(long projectId)
        {
            return await _context.Tasks
                .Where(t => t.ProjectId == projectId)
                .ToListAsync();
        }
    }
}