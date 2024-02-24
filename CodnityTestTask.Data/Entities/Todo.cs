using Microsoft.EntityFrameworkCore;

namespace CodnityTestTask.Data.Entities;

public class Todo
{
    public int Id { get; set; }

    public string Text { get; set; }

    public bool IsCompleted { get; set; }

    public static void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todo>().HasKey(x => x.Id);
    }
}