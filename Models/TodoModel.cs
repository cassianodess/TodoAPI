using System.ComponentModel.DataAnnotations;

namespace TodoAPI.Models;

public class TodoModel {
    public Guid? Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool? Completed { get; set; } = false;

    public TodoModel(string title, string description) {
        this.Id = Guid.NewGuid();
        this.Title = title;
        this.Description = description;
        this.Completed = false;
    }
}