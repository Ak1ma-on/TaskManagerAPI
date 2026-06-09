using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Data;

namespace TaskManagerAPI.Services
{
    public class DbTaskService : ITaskService
    {
        private DbTaskContext _dbContext;
        public DbTaskService(DbTaskContext dbContext)
        { 
            _dbContext = dbContext;
        }

        public async Task<List<TaskItem>> GetAllAsync()
        {
            return await _dbContext.Tasks.ToListAsync();

        }
        
        public async Task<TaskItem?> GetByIdAsync(int id)
        {
            return await _dbContext.Tasks.FindAsync(id);
        }

        public async Task AddTaskAsync(string name, string? description)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Пустое название задачи");
            var item = new TaskItem(name, description);
            _dbContext.Tasks.Add(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> RemoveTaskAsync(int id)
        {
            var taskToRemove = await _dbContext.Tasks.FindAsync(id);
            if (taskToRemove == null) return false;

            _dbContext.Tasks.Remove(taskToRemove);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateTaskAsync(int id, string name, string? description, bool isCompleted)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Пустое название задачи");
            var taskToUpdate = await _dbContext.Tasks.FindAsync(id);
            if (taskToUpdate == null) return false;

            taskToUpdate.Name = name;
            taskToUpdate.Description = description;
            taskToUpdate.IsCompleted = isCompleted;

            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
