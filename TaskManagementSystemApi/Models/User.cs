namespace TaskManagementSystemApi.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public ICollection<Tasks> AssignedTasks { get; set; }
        public ICollection<Tasks> CreatedTasks { get; set; }
        public ICollection<Projects> MemberOfProjects { get; set; }
    }
}