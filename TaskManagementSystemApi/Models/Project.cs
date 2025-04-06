namespace TaskManagementSystemApi.Models
{
    public class Project
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public ICollection<Models.Task> Tasks { get; set; } = new List<Models.Task>();
        public ICollection<User> Members { get; set; } = new List<User>();
    }
}