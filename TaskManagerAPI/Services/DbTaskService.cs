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

        public List<TaskItem> GetAll()
        {
            return _dbContext.Tasks.ToList();
        }
        
        public TaskItem? GetById(int id)
        {
            return _dbContext.Tasks.Find(id);
        }

        public void AddTask(string name, string? description)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Пустое название задачи");
            var task = new TaskItem(name, description);
            _dbContext.Tasks.Add(task);
            _dbContext.SaveChanges();
        }

        public bool RemoveTask(int id)
        {
            var taskToRemove = _dbContext.Tasks.Find(id);
            if (taskToRemove == null) return false;

            _dbContext.Tasks.Remove(taskToRemove);
            _dbContext.SaveChanges();
            return true;
        }

        public bool UpdateTask(int id, string name, string? description, bool isCompleted)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Пустое название задачи");
            var taskToUpdate = _dbContext.Tasks.Find(id);
            if (taskToUpdate == null) return false;

            taskToUpdate.Name = name;
            taskToUpdate.Description = description;
            taskToUpdate.IsCompleted = isCompleted;

            _dbContext.SaveChanges();
            return true;
        }
    }
}
