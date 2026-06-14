namespace TaskManagerAPI.Services
{
    public interface ITaskService
    {
        public Task<List<TaskItem>>GetAllAsync(int userId);     
        public Task<bool> RemoveTaskAsync(int userId, int id);
        public Task<TaskItem?> GetByIdAsync(int userId, int id);
        public Task<bool> UpdateTaskAsync(int userId, int id, string name, string? description, bool isCompleted);
        public Task AddTaskAsync(int userId, string name, string? description);

    }
}
