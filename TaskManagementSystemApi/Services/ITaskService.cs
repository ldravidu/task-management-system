using TaskManagementSystemApi.DTOs;

namespace TaskManagementSystemApi.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDTO>> GetAllTasks();
        Task<TaskDTO?> GetTaskById(long id);
        Task<TaskDTO> CreateTask(CreateTaskDTO taskDTO, long userId);
        Task<TaskDTO?> UpdateTask(long id, UpdateTaskDTO taskDTO);
        Task<bool> DeleteTask(long id);
        Task<IEnumerable<TaskDTO>> GetTasksByUserId(long userId);
        Task<IEnumerable<TaskDTO>> GetTasksByProjectId(long projectId);
    }
}