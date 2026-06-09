using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private TaskService _taskService;
        public TasksController(TaskService taskService) 
        {
            _taskService = taskService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_taskService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var task = _taskService.GetById(id);
            if (task == null) return NotFound();
            return Ok(task);
        }


        [HttpPost] 
        public IActionResult CreateTask([FromBody] TaskItemDTO task)
        {
            _taskService.AddTask(task.Name, task.Description);
            return Created();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, [FromBody] UpdateTaskRequest task)
        {
            if (_taskService.UpdateTask(id, task.Name, task.Description, task.isCompleted)) return Ok($"Задача №{id} обновлена.");
            else return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            if (_taskService.RemoveTask(id)) return Ok($"Задача №{id} удалена.");
            else return NoContent();
        }
    }
}
