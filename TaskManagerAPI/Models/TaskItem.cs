public class TaskItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsCompleted { get; set; }
    public string? Description { get; set; }

    public TaskItem(int id, string name, string? description)
    {
        Id = id;
        Name = name;
        Description = description;
        IsCompleted = false;
    }
}