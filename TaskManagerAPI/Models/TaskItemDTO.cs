using System.ComponentModel.DataAnnotations;

namespace TaskManagerAPI.Models
{
    public class TaskItemDTO
    {
       [Required] public string Name { get; set; }
        public string? Description { get; set; }
    }
}
