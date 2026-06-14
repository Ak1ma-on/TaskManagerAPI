public class TaskItem
{
    public int Id { get; set; }
    public int UserId {get; set;}
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
    public TaskItem(string name, string? description)
    {
        Name = name;
        Description = description;
        IsCompleted = false;
    }
}