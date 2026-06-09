namespace TaskManagerAPI.Services
{
    public interface ITaskService
    {
        public Task<List<TaskItem>>GetAllAsync();     
        public Task<bool> RemoveTaskAsync(int id);
        public Task<TaskItem?> GetByIdAsync(int id);
        public Task<bool> UpdateTaskAsync(int id, string name, string? description, bool isCompleted);
        public Task AddTaskAsync(string name, string? description);

    }
}
