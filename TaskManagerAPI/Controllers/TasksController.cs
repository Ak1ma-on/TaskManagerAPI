using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Models;
using TaskManagerAPI.Services;

namespace TaskManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TasksController : ControllerBase
    {
        
        private ITaskService _taskService;
        public TasksController(ITaskService taskService) 
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return Ok(await _taskService.GetAllAsync(userId));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var task = await _taskService.GetByIdAsync(userId, id);
            if (task == null) return NotFound();            
            return Ok(task);
        }


        [HttpPost] 
        public async Task<IActionResult> CreateTaskAsync([FromBody] TaskItemDTO task)
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _taskService.AddTaskAsync(userId, task.Name, task.Description);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaskAsync(int id, [FromBody] UpdateTaskRequest task)
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (await _taskService.UpdateTaskAsync(userId, id, task.Name, task.Description, task.isCompleted)) return Ok($"Задача №{id} обновлена.");
            else return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskAsync(int id)
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (await _taskService.RemoveTaskAsync(userId, id)) return Ok($"Задача №{id} удалена.");
            else return NotFound();
        }
    }
}
