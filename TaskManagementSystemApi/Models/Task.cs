namespace TaskManagementSystemApi.Models;

public class Task
{
    public long Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public TaskStatus Status { get; set; }
    public TaskPriority Priority { get; set; }

    public long CreatedById { get; set; }
    public long AssignedToId { get; set; }
    public long ProjectId { get; set; }

}

public enum TaskStatus
{
    New,
    InProgress,
    Completed,
    Closed
}
public enum TaskPriority
{
    Low,
    Medium,
    High
}
