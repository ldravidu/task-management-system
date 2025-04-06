using TaskManagementSystemApi.DTOs;

namespace TaskManagementSystemApi.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsers();
        Task<UserDTO?> GetUserById(long id);
        Task<UserDTO?> GetUserByEmail(string email);
        Task<UserDTO> CreateUser(CreateUserDTO userDTO);
        Task<UserDTO?> UpdateUser(long id, UpdateUserDTO userDTO);
        Task<bool> DeleteUser(long id);
        Task<IEnumerable<UserDTO>> GetUsersByProjectId(long projectId);
    }
}
