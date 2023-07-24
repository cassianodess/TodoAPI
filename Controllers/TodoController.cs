using Microsoft.AspNetCore.Mvc;
using TodoAPI.Context;
using TodoAPI.Models;
using TodoAPI.DTO;

namespace TodoAPI.Controllers;

[ApiController]
[Route("/todos")]
public class TodoController : ControllerBase
{

    private readonly RepositoryContext repository;

    public TodoController(RepositoryContext repository)
    {
        this.repository = repository;
    }


    [HttpGet]
    public IActionResult ListAll(string? title, bool completed = false)
    {

        List<TodoModel>? todos;

        if (string.IsNullOrEmpty(title))
        {
            todos = repository.Todos.Where(todo => todo.Completed == completed).ToList();

        }
        else
        {
            todos = repository.Todos.Where(todo => todo.Title.ToLower().Contains(title!.ToLower()) && todo.Completed == completed).ToList();
        }

        return Ok(new
        {
            message = "todos has been listed successfully",
            todos
        });
    }

    [HttpGet("{id}")]
    public IActionResult FindById(Guid id)
    {

        TodoModel? todo = repository.Todos.Find(id);

        if (todo != null)
        {
            return Ok(new
            {
                message = "todo has been retrieved successfully",
                todo
            });
        }

        return NotFound(new
        {
            message = "todo not found",

        });

    }

    [HttpPost]
    public IActionResult Create([FromBody] TodoDTO todo)
    {
        if(!ModelState.IsValid) {
            return BadRequest(new{
                message = "invalid data, check required body fields"
            });
        }

        TodoModel _todo = new TodoModel(todo.Title.Trim(), todo.Description.Trim());
        repository.Add(_todo);
        repository.SaveChanges();
        return CreatedAtAction(nameof(FindById), new {id = _todo.Id}, new {
            message = "todo has been created successfully",
            todo
        });
    }

    [HttpPut("{id}")]
    public IActionResult Update(Guid id, [FromBody] TodoDTO todo)
    {

        TodoModel? _todo = repository.Todos.Find(id);

        if (_todo != null)
        {
            _todo.Title = todo.Title;
            _todo.Description = todo.Description;
            _todo.Completed = todo.Completed;
            repository.Todos.Update(_todo);
            repository.SaveChanges();

            return Ok(new
            {
                message = "todo has been updated successfully",
                todo
            });
        }

        return NotFound(new
        {
            message = "todo not found",

        });

    }

    [HttpDelete("{id}")]
    public IActionResult Detele(Guid id)
    {
        TodoModel? todo = repository.Todos.Find(id);

        if (todo != null)
        {
            repository.Todos.Remove(todo);
            repository.SaveChanges();
            return Ok(new
            {
                message = "todo has been deleted successfully",
                todo
            });
        }

        return NotFound(new
        {
            message = "todo not found"
        });

    }



}