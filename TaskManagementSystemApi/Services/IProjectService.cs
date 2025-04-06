using TaskManagementSystemApi.DTOs;

namespace TaskManagementSystemApi.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectDTO>> GetAllProjects();
        Task<ProjectDTO?> GetProjectById(long id);
        Task<ProjectDTO> CreateProject(CreateProjectDTO projectDTO);
        Task<ProjectDTO?> UpdateProject(long id, UpdateProjectDTO projectDTO);
        Task<bool> DeleteProject(long id);
        Task<IEnumerable<ProjectDTO>> GetProjectsByUserId(long userId);
        Task<bool> AddMember(long projectId, long userId);
        Task<bool> RemoveMember(long projectId, long userId);
    }
}
