namespace TaskManagementSystemApi.DTOs
{
    public class TaskDTO
    {
        public long Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Models.TaskPriority Priority { get; set; } = Models.TaskPriority.Medium;
        public Models.TaskStatus Status { get; set; } = Models.TaskStatus.Todo;

        public long CreatedById { get; set; }
        public long? AssignedToId { get; set; }
        public long? ProjectId { get; set; }
    }

    public class CreateTaskDTO
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public Models.TaskPriority Priority { get; set; } = Models.TaskPriority.Medium;
        public Models.TaskStatus Status { get; set; } = Models.TaskStatus.Todo;

        public long? AssignedToId { get; set; }
        public long? ProjectId { get; set; }
    }

    public class UpdateTaskDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public Models.TaskPriority? Priority { get; set; } = Models.TaskPriority.Medium;
        public Models.TaskStatus? Status { get; set; } = Models.TaskStatus.Todo;
        public long? AssignedToId { get; set; }
        public long? ProjectId { get; set; }
    }
}