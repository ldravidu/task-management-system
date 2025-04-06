using TaskManagementSystemApi.Models;

namespace TaskManagementSystemApi.Repositories
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<IEnumerable<Project?>> GetProjectsWithDetails();
        Task<Project?> GetProjectWithDetails(long id);
        Task<IEnumerable<Project>> GetProjectsByUserId(long userId);
    }
}
