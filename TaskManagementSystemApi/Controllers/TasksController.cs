using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystemApi.DTOs;
using TaskManagementSystemApi.Models;
using TaskManagementSystemApi.Services;

namespace TaskManagementSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        // GET: api/Tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskDTO>>> GetTasks()
        {
            var tasks = await _taskService.GetAllTasks();
            return Ok(tasks);
        }

        // GET: api/Tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDTO>> GetTask(long id)
        {
            var task = await _taskService.GetTaskById(id);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        // POST: api/Tasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaskDTO>> CreateTask(CreateTaskDTO taskDTO)
        {
            // TODO: Replace with real value
            int currentUserId = 1;

            var createdTask = await _taskService.CreateTask(taskDTO, currentUserId);
            return CreatedAtAction(nameof(GetTask), new { id = createdTask.Id }, createdTask);
        }

        // PUT: api/Tasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskDTO(int id, UpdateTaskDTO taskDTO)
        {
            var updatedTask = await _taskService.UpdateTask(id, taskDTO);

            if (updatedTask == null)
            {
                return NotFound();
            }

            return Ok(updatedTask);
        }



        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskDTO(int id)
        {
            var deleted = await _taskService.DeleteTask(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<TaskDTO>>> GetTasksByUserId(long userId)
        {
            var tasks = await _taskService.GetTasksByUserId(userId);
            return Ok(tasks);
        }

        [HttpGet("project/{projectId}")]
        public async Task<ActionResult<IEnumerable<TaskDTO>>> GetTasksByProjectId(long projectId)
        {
            var tasks = await _taskService.GetTasksByProjectId(projectId);
            return Ok(tasks);
        }
    }
}
