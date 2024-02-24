using CodnityTestTask.Data.Entities;
using CodnityTestTask.Data.Repositories;
using CodnityTestTask.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodnityTestTask.Web.Controllers;

public class HomeController(ITodoRepository todoRepository)
    : Controller
{
    public async Task<IActionResult> Index()
    {
        return View();
    }

    [Route("/api/getTodos")]
    public async Task<HomeViewModel> GetTodos()
    {
        var todos = await todoRepository.GetAllTodos();

        var model = new HomeViewModel
        {
            TodosList = todos,
        };

        return model;
    }

    [Route("/api/addTodo")]
    [HttpPost]
    public async Task<IActionResult> AddTodo([FromBody] AddTodoRequestViewModel formData)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await todoRepository.AddTodo(new Todo
        {
            Text = formData.Text
        });

        return Ok();
    }

    [Route("/api/deleteTodo")]
    [HttpPost]
    public async Task<IActionResult> DeleteTodo([FromBody]DeleteTodoRequestViewModel formData)
    {
        try
        {
            await todoRepository.DeleteTodo(formData.Id);

            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [Route("/api/toggleTodo")]
    [HttpPost]
    public async Task<IActionResult> ToggleTodo([FromBody] ToggleTodoRequestViewModel formData)
    {
        try
        {
            await todoRepository.ToggleTodo(formData.Id, formData.Value);

            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}