using Microsoft.EntityFrameworkCore;
using TodoAPI.Models;

namespace TodoAPI.Context;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<TodoModel> Todos {get;set;}
}