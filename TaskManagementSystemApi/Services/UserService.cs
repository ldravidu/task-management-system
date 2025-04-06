using TaskManagementSystemApi.DTOs;
using TaskManagementSystemApi.Models;
using TaskManagementSystemApi.Repositories;

namespace TaskManagementSystemApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsers()
        {
            var users = await _userRepository.GetAll();
            return users.Select(MapToUserDto);
        }

        public async Task<UserDTO?> GetUserById(long id)
        {
            var user = await _userRepository.GetUserWithDetails(id);
            return user != null ? MapToUserDto(user) : null;
        }

        public async Task<UserDTO?> GetUserByEmail(string email)
        {
            var user = await _userRepository.GetByEmail(email);
            return user != null ? MapToUserDto(user) : null;
        }

        public async Task<UserDTO> CreateUser(CreateUserDTO userDto)
        {
            if (await _userRepository.CheckEmailExists(userDto.Email))
                throw new InvalidOperationException("Email already exists");

            var user = new User
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Password = userDto.Password // TODO: Add password hashing
            };

            await _userRepository.Add(user);
            await _userRepository.SaveChanges();

            return MapToUserDto(user);
        }

        public async Task<UserDTO?> UpdateUser(long id, UpdateUserDTO userDto)
        {
            var user = await _userRepository.GetById(id);
            if (user == null) return null;

            if (userDto.Email != null && user.Email != userDto.Email)
            {
                if (await _userRepository.CheckEmailExists(userDto.Email))
                    throw new InvalidOperationException("Email already exists");
                user.Email = userDto.Email;
            }

            if (userDto.Name != null)
                user.Name = userDto.Name;

            if (userDto.Password != null)
                user.Password = userDto.Password; // TODO: Add password hashing

            await _userRepository.Update(user);
            await _userRepository.SaveChanges();

            return MapToUserDto(user);
        }

        public async Task<bool> DeleteUser(long id)
        {
            var user = await _userRepository.GetById(id);
            if (user == null) return false;

            await _userRepository.Delete(user);
            await _userRepository.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<UserDTO>> GetUsersByProjectId(long projectId)
        {
            var users = await _userRepository.GetUsersByProjectId(projectId);
            return users.Select(MapToUserDto);
        }

        private static UserDTO MapToUserDto(User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }
    }
}
