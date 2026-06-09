using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Models;
using TaskManagerAPI.Services;

namespace TaskManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
            return Ok(await _taskService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var task = await _taskService.GetByIdAsync(id);
            if (task == null) return NotFound();
            return Ok(task);
        }


        [HttpPost] 
        public async Task<IActionResult> CreateTaskAsync([FromBody] TaskItemDTO task)
        {
            await _taskService.AddTaskAsync(task.Name, task.Description);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaskAsync(int id, [FromBody] UpdateTaskRequest task)
        {
            if (await _taskService.UpdateTaskAsync(id, task.Name, task.Description, task.isCompleted)) return Ok($"Задача №{id} обновлена.");
            else return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskAsync(int id)
        {
            if (await _taskService.RemoveTaskAsync(id)) return Ok($"Задача №{id} удалена.");
            else return NotFound();
        }
    }
}
