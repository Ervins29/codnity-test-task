using CodnityTestTask.Data.DbContexts;
using CodnityTestTask.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodnityTestTask.Data.Repositories;

public class TodoRepository(TodoDbContext dbContext) : ITodoRepository
{
    public async Task<List<Todo>> GetAllTodos()
    {
        return await dbContext.Todos.ToListAsync();
    }

    public async Task AddTodo(Todo todo)
    {
        dbContext.Todos.Add(todo);

        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteTodo(int id)
    {
        var todoToBeDeleted = await dbContext.Todos.FirstOrDefaultAsync(x => x.Id == id);

        if (todoToBeDeleted is null)
        {
            throw new Exception("Entity not found");
        }

        dbContext.Todos.Remove(todoToBeDeleted);

        await dbContext.SaveChangesAsync();
    }

    public async Task ToggleTodo(int id, bool value)
    {
        var todoToToggle = await dbContext.Todos.FindAsync(id);

        if (todoToToggle is null)
        {
            throw new Exception("Entity not found");
        }

        todoToToggle.IsCompleted = value;

        await dbContext.SaveChangesAsync();
    }
}