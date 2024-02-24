using CodnityTestTask.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodnityTestTask.Data.DbContexts;

public class TodoDbContext(DbContextOptions<TodoDbContext> options) : DbContext(options)
{
    public DbSet<Todo> Todos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Todo.OnModelCreating(modelBuilder);
    }
}