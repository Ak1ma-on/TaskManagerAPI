namespace TaskManagerAPI.Models
{
    public class TaskService
    {
        private int _currentId = 1;
        private List<TaskItem> _tasks = new List<TaskItem>();

        public void AddTask(string name, string? description)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Пустое название задачи");
            _tasks.Add(new TaskItem(_currentId, name, description));
            _currentId++;
        }

        public TaskItem? GetById(int id)
        {
            return _tasks.FirstOrDefault(x => x.Id == id);
        }

        public bool RemoveTask(int id)
        {
            TaskItem taskToDelete = _tasks.Find(x => x.Id == id);
            if (taskToDelete != null)
            {
                _tasks.Remove(taskToDelete);
                return true;
            }
            return false;
        }

        public List<TaskItem> GetAll()
        {
            return _tasks.ToList();
        }

        public bool MarkAsCompleted(int id)
        {
            TaskItem taskToMark = _tasks.Find(x => x.Id == id);
            if (taskToMark != null)
            {
                taskToMark.IsCompleted = true;
                return true;
            }
            return false;
        }

        public bool UpdateTask(int id, string name, string? description, bool isCompleted)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Пустое название задачи");
            var taskToUpdate = _tasks.Find(x => x.Id == id);

            if (taskToUpdate != null)
            {
                taskToUpdate.IsCompleted = isCompleted;
                taskToUpdate.Name = name;
                taskToUpdate.Description = description;
                return true;
            }
            return false;
        }
    }
}
