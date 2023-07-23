namespace TodoAPI.Models;

public class TodoModel {
    public Guid Id { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public bool Completed { get; set; } = false;
}