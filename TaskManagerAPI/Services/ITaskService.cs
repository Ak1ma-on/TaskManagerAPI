namespace TaskManagerAPI.Services
{
    public interface ITaskService
    {
        public List<TaskItem> GetAll();     
        public bool RemoveTask(int id);
        public TaskItem? GetById(int id);
        public bool UpdateTask(int id, string name, string? description, bool isCompleted);
        public void AddTask(string name, string? description);

    }
}
