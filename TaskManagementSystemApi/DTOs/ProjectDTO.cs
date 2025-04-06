namespace TaskManagementSystemApi.DTOs
{
    public class ProjectDTO
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public ICollection<long> MemberIds { get; set; } = new List<long>();
    }

    public class CreateProjectDTO
    {
        public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public ICollection<long> MemberIds { get; set; } = new List<long>();
    }

    public class UpdateProjectDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ICollection<long>? MemberIds { get; set; }
    }
}
