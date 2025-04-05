namespace TaskManagementSystemApi.DTOs
{
    public class TaskDTO
    {
        public long Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public DateOnly? DueDate { get; set; }
        public DateOnly CreatedDate { get; set; }
        public DateOnly UpdatedDate { get; set; }
        public string Priority { get; set; } = nameof(Models.TaskPriority.Medium);
        public string Status { get; set; } = nameof(Models.TaskStatus.Todo);

        public long CreatedById { get; set; }
        public long? AssignedToId { get; set; }
        public long? ProjectId { get; set; }
    }

    public class CreateTaskDTO
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public DateOnly? DueDate { get; set; }
        public string? Priority { get; set; } = nameof(Models.TaskPriority.Medium);

        public long? AssignedToId { get; set; }
        public long? ProjectId { get; set; }
    }

    public class UpdateTaskDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateOnly? DueDate { get; set; }
        public string? Priority { get; set; } = nameof(Models.TaskPriority.Medium);
        public string? Status { get; set; } = nameof(Models.TaskStatus.Todo);
        public long? AssignedToId { get; set; }
        public long? ProjectId { get; set; }
    }
}