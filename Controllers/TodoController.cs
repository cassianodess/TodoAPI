using Microsoft.AspNetCore.Mvc;
using TodoAPI.Context;
using TodoAPI.Models;

namespace TodoAPI.Controllers;

[ApiController]
[Route("/todos")]
public class TodoController: ControllerBase {

    private readonly TodoContext context;

    public TodoController(TodoContext context)  {
        this.context = context; 
    }

    [HttpPost]
    public IActionResult Create(TodoModel todo) {
        todo.Id = Guid.NewGuid();
        context.Add(todo);
        context.SaveChanges();
        return Ok(todo);
    }
    

}