namespace TaskManagementSystemApi.Models;

public class Task
{
    public long Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public DateOnly? DueDate { get; set; }
    public DateOnly CreatedDate { get; set; }
    public DateOnly UpdatedDate { get; set; }
    public TaskStatus Status { get; set; }
    public TaskPriority Priority { get; set; }

    public long CreatedById { get; set; }
    public long? AssignedToId { get; set; }
    public long? ProjectId { get; set; }

    public User? CreatedBy { get; set; }
    public User? AssignedTo { get; set; }
    public Project? Project { get; set; }

}

public enum TaskStatus
{
    Todo,
    InProgress,
    Completed,
    Closed
}
public enum TaskPriority
{
    Low,
    Medium,
    High,
    Urgent
}
