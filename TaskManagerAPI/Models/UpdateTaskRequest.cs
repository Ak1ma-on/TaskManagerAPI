using System.ComponentModel.DataAnnotations;

namespace TaskManagerAPI.Models
{
    public class UpdateTaskRequest
    {
       [Required] public string Name { get; set; }
        public string? Description { get; set; }
        public bool isCompleted { get; set; }
    }
}
