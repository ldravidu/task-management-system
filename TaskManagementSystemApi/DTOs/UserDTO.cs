namespace TaskManagementSystemApi.DTOs
{
    public class UserDTO
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
    }

    public class CreateUserDTO
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }

    public class UpdateUserDTO
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
