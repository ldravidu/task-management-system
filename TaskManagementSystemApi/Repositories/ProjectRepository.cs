using Microsoft.EntityFrameworkCore;
using TaskManagementSystemApi.Data;
using TaskManagementSystemApi.Models;

namespace TaskManagementSystemApi.Repositories
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Project?>> GetProjectsWithDetails()
        {
            return await _context.Projects
                .Include(p => p.Tasks)
                .Include(p => p.Members)
                .ToListAsync();
        }

        public async Task<Project?> GetProjectWithDetails(long id)
        {
            return await _context.Projects
                .Include(p => p.Tasks)
                .Include(p => p.Members)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Project>> GetProjectsByUserId(long userId)
        {
            return await _context.Projects
                .Include(p => p.Members)
                .Where(p => p.Members.Any(m => m.Id == userId))
                .ToListAsync();
        }
    }
}
