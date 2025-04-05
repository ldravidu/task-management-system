using TaskManagementSystemApi.Repositories;
using TaskManagementSystemApi.DTOs;
using TaskManagementSystemApi.Models;

namespace TaskManagementSystemApi.Services
{
    public class TaskService : ITaskService

    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<IEnumerable<TaskDTO>> GetAllTasks()
        {
            var tasks = await _taskRepository.GetTasksWithDetails();
            return tasks.Select(MapToTaskDto);
        }

        public async Task<TaskDTO?> GetTaskById(long id)
        {
            var task = await _taskRepository.GetTaskWithDetails(id);
            return task != null ? MapToTaskDto(task) : null;
        }

        public async Task<TaskDTO> CreateTask(CreateTaskDTO taskDto, long currentUserId)
        {
            var task = new Models.Task
            {
                Title = taskDto.Title,
                Description = taskDto.Description,
                CreatedDate = DateTime.UtcNow,
                DueDate = taskDto.DueDate,
                Priority = taskDto.Priority,
                Status = Models.TaskStatus.Todo,
                ProjectId = taskDto.ProjectId,
                AssignedToId = taskDto.AssignedToId,
                CreatedById = currentUserId,
                UpdatedDate = DateTime.Now,
            };

            await _taskRepository.Add(task);
            await _taskRepository.SaveChanges();

            var createdTask = await _taskRepository.GetTaskWithDetails(task.Id);
            return MapToTaskDto(createdTask!);
        }

        public async Task<TaskDTO?> UpdateTask(long id, UpdateTaskDTO taskDto)
        {
            var task = await _taskRepository.GetTaskWithDetails(id);
            if (task == null)
            {
                return null;
            }

            if (taskDto.Title != null)
                task.Title = taskDto.Title;

            if (taskDto.Description != null)
                task.Description = taskDto.Description;

            if (taskDto.DueDate != null)
                task.DueDate = taskDto.DueDate;

            if (taskDto.Status != null)
                task.Status = (Models.TaskStatus)taskDto.Status;

            if (taskDto.Priority != null)
                task.Priority = (TaskPriority)taskDto.Priority;

            if (taskDto.AssignedToId != null)
                task.AssignedToId = taskDto.AssignedToId;

            await _taskRepository.Update(task);
            await _taskRepository.SaveChanges();

            var updatedTask = await _taskRepository.GetTaskWithDetails(id);

            return updatedTask != null ? MapToTaskDto(updatedTask) : null;
        }

        public async Task<bool> DeleteTask(long id)
        {
            var task = await _taskRepository.GetById(id);
            if (task == null)
                return false;

            await _taskRepository.Delete(task);
            await _taskRepository.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<TaskDTO>> GetTasksByUserId(long userId)
        {
            var tasks = await _taskRepository.GetTasksByUserId(userId);
            return tasks.Select(MapToTaskDto);
        }

        public async Task<IEnumerable<TaskDTO>> GetTasksByProjectId(long projectId)
        {
            var tasks = await _taskRepository.GetTasksByProjectId(projectId);
            return tasks.Select(MapToTaskDto);
        }


        private static TaskDTO MapToTaskDto(Models.Task task)
        {
            return new TaskDTO
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                Priority = task.Priority,
                Status = task.Status,
                ProjectId = task.ProjectId,
                AssignedToId = task.AssignedToId,
                CreatedDate = task.CreatedDate,
                UpdatedDate = task.UpdatedDate,
            };
        }
    }
}