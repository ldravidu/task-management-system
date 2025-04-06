using TaskManagementSystemApi.Models;

namespace TaskManagementSystemApi.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetUserWithDetails(long id);
        Task<IEnumerable<User>> GetUsersByProjectId(long projectId);
        Task<bool> CheckEmailExists(string email);
        Task<User?> GetByEmail(string email);
    }
}
