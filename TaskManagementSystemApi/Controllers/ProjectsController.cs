using Microsoft.AspNetCore.Mvc;
using TaskManagementSystemApi.DTOs;
using TaskManagementSystemApi.Services;

namespace TaskManagementSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDTO>>> GetProjects()
        {
            var projects = await _projectService.GetAllProjects();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDTO>> GetProject(long id)
        {
            var project = await _projectService.GetProjectById(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        [HttpPost]
        public async Task<ActionResult<ProjectDTO>> CreateProject(CreateProjectDTO projectDTO)
        {
            var createdProject = await _projectService.CreateProject(projectDTO);
            return CreatedAtAction(nameof(GetProject), new { id = createdProject.Id }, createdProject);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(long id, UpdateProjectDTO projectDTO)
        {
            var updatedProject = await _projectService.UpdateProject(id, projectDTO);
            if (updatedProject == null)
            {
                return NotFound();
            }
            return Ok(updatedProject);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(long id)
        {
            var deleted = await _projectService.DeleteProject(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<ProjectDTO>>> GetProjectsByUser(long userId)
        {
            var projects = await _projectService.GetProjectsByUserId(userId);
            return Ok(projects);
        }

        [HttpPost("{id}/members/{userId}")]
        public async Task<IActionResult> AddMember(long id, long userId)
        {
            var success = await _projectService.AddMember(id, userId);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}/members/{userId}")]
        public async Task<IActionResult> RemoveMember(long id, long userId)
        {
            var success = await _projectService.RemoveMember(id, userId);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
