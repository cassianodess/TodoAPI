namespace TodoAPI.DTO;

public class TodoDTO
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool? Completed { get; set; } = false;

}