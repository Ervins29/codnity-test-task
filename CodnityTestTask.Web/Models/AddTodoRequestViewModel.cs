using System.ComponentModel.DataAnnotations;

namespace CodnityTestTask.Web.Models;

public class AddTodoRequestViewModel
{
    [Required(ErrorMessage = "Text is required")]
    public string Text { get; set; }
}