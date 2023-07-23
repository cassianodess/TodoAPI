using Microsoft.EntityFrameworkCore;
using TodoAPI.Models;

namespace TodoAPI.Context;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<TodoModel> Todos {get;set;}
}