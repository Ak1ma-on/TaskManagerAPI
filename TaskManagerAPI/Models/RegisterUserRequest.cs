using System.ComponentModel.DataAnnotations;

namespace TaskManagerAPI.Models;
public class RegisterUserRequest
{
    [Required] public string Username {get; set;}
    [Required] public string Password {get; set;}
}