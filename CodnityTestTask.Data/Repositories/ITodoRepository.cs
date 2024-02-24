using CodnityTestTask.Data.Entities;

namespace CodnityTestTask.Data.Repositories;

public interface ITodoRepository
{
    Task<List<Todo>> GetAllTodos();

    Task AddTodo(Todo todo);

    Task DeleteTodo(int id);

    Task ToggleTodo(int id, bool value);
}