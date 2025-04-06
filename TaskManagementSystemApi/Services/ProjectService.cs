using TaskManagementSystemApi.DTOs;
using TaskManagementSystemApi.Models;
using TaskManagementSystemApi.Repositories;

namespace TaskManagementSystemApi.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUserRepository _userRepository;

        public ProjectService(IProjectRepository projectRepository, IUserRepository userRepository)
        {
            _projectRepository = projectRepository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<ProjectDTO>> GetAllProjects()
        {
            var projects = await _projectRepository.GetProjectsWithDetails();
            return projects.Select(p => MapToProjectDto(p!));
        }

        public async Task<ProjectDTO?> GetProjectById(long id)
        {
            var project = await _projectRepository.GetProjectWithDetails(id);
            return project != null ? MapToProjectDto(project) : null;
        }

        public async Task<ProjectDTO> CreateProject(CreateProjectDTO projectDto)
        {
            var project = new Project
            {
                Name = projectDto.Name,
                Description = projectDto.Description,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            };

            await _projectRepository.Add(project);
            await _projectRepository.SaveChanges();

            if (projectDto.MemberIds.Any())
            {
                foreach (var memberId in projectDto.MemberIds)
                {
                    await AddMember(project.Id, memberId);
                }
            }

            var createdProject = await _projectRepository.GetProjectWithDetails(project.Id);
            return MapToProjectDto(createdProject!);
        }

        public async Task<ProjectDTO?> UpdateProject(long id, UpdateProjectDTO projectDto)
        {
            var project = await _projectRepository.GetProjectWithDetails(id);
            if (project == null) return null;

            if (projectDto.Name != null)
                project.Name = projectDto.Name;
            if (projectDto.Description != null)
                project.Description = projectDto.Description;

            project.UpdatedDate = DateTime.UtcNow;

            await _projectRepository.Update(project);
            await _projectRepository.SaveChanges();

            if (projectDto.MemberIds != null)
            {
                var currentMembers = project.Members.Select(m => m.Id).ToList();
                var membersToAdd = projectDto.MemberIds.Except(currentMembers);
                var membersToRemove = currentMembers.Except(projectDto.MemberIds);

                foreach (var memberId in membersToAdd)
                {
                    await AddMember(id, memberId);
                }

                foreach (var memberId in membersToRemove)
                {
                    await RemoveMember(id, memberId);
                }
            }

            var updatedProject = await _projectRepository.GetProjectWithDetails(id);
            return updatedProject != null ? MapToProjectDto(updatedProject) : null;
        }

        public async Task<bool> DeleteProject(long id)
        {
            var project = await _projectRepository.GetById(id);
            if (project == null) return false;

            await _projectRepository.Delete(project);
            await _projectRepository.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<ProjectDTO>> GetProjectsByUserId(long userId)
        {
            var projects = await _projectRepository.GetProjectsByUserId(userId);
            return projects.Select(MapToProjectDto);
        }

        public async Task<bool> AddMember(long projectId, long userId)
        {
            var project = await _projectRepository.GetProjectWithDetails(projectId);
            var user = await _userRepository.GetById(userId);

            if (project == null || user == null) return false;
            if (project.Members.Any(m => m.Id == userId)) return true;

            project.Members.Add(user);
            await _projectRepository.SaveChanges();
            return true;
        }

        public async Task<bool> RemoveMember(long projectId, long userId)
        {
            var project = await _projectRepository.GetProjectWithDetails(projectId);
            if (project == null) return false;

            var member = project.Members.FirstOrDefault(m => m.Id == userId);
            if (member == null) return true;

            project.Members.Remove(member);
            await _projectRepository.SaveChanges();
            return true;
        }

        private static ProjectDTO MapToProjectDto(Project project)
        {
            return new ProjectDTO
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                CreatedDate = project.CreatedDate,
                UpdatedDate = project.UpdatedDate,
                MemberIds = project.Members.Select(m => m.Id).ToList()
            };
        }
    }
}
