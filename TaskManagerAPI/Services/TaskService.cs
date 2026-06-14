// DEPRICATED
// namespace TaskManagerAPI.Services
// {
//     public class TaskService : ITaskService
//     {
//         private int _currentId = 1;
//         private List<TaskItem> _tasks = new List<TaskItem>();

//         public Task AddTaskAsync(string name, string? description)
//         {
//             if (string.IsNullOrEmpty(name)) throw new ArgumentException("Пустое название задачи");
//             _tasks.Add(new TaskItem(_currentId, name, description));
//             _currentId++;
//             return Task.CompletedTask;
//         }

//         private TaskItem? GetById(int id)
//         {
//             var task = _tasks.FirstOrDefault(x => x.Id == id);
//             return task;
//         }

//         public Task<TaskItem?> GetByIdAsync(int id)
//         {
//             var result = GetById(id);
//             return Task.FromResult(result);
//         }

//         private bool RemoveTask(int id)
//         {
//             TaskItem taskToDelete = _tasks.Find(x => x.Id == id);
//             if (taskToDelete != null)
//             {
//                 _tasks.Remove(taskToDelete);
//                 return true;
//             }
//             return false;
//         }

//         public Task<bool> RemoveTaskAsync(int id)
//         {
//             var result = RemoveTask(id);
//             return Task.FromResult(result);
//         }

//         public Task<List<TaskItem>> GetAllAsync()
//         {
//             return Task.FromResult(_tasks.ToList());
//         }
       
//         private bool UpdateTask(int id, string name, string? description, bool isCompleted)
//         {
//             if (string.IsNullOrEmpty(name)) throw new ArgumentException("Пустое название задачи");
//             var taskToUpdate = _tasks.Find(x => x.Id == id);

//             if (taskToUpdate != null)
//             {
//                 taskToUpdate.IsCompleted = isCompleted;
//                 taskToUpdate.Name = name;
//                 taskToUpdate.Description = description;
//                 return true;
//             }
//             return false;
//         }

//         public Task<bool> UpdateTaskAsync(int id, string name, string? description, bool isCompleted)
//         {
//             var result = UpdateTask(id, name, description, isCompleted);
//             return Task.FromResult(result);
//         }
//     }
// }
