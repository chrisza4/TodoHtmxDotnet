using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TodoHtmx.Web.Models;
using TodoHtmx.Web.Repositories;
using TodoHtmx.Web.ViewModels;

namespace TodoHtmx.Web.Controllers;

public class TodoController : Controller
{
    private readonly ILogger<TodoController> _logger;
    private readonly TodoRepository todoRepository;

    public TodoController(TodoRepository todoRepository, ILogger<TodoController> logger)
    {
        _logger = logger;
        this.todoRepository = todoRepository;
    }

    public IActionResult Index()
    {
        return View();
    }

    private IActionResult todoItemsViewWithFilter()
    {
        var filterMode = RequestHelper.TodoFilterModeFromQueryString(Request.Query["filter"]);
        return PartialView("TodoItems", this.todoRepository.GetTodos(filterMode));
    }

    public IActionResult TodoItems()
    {
        return todoItemsViewWithFilter();
    }

    [HttpPost]
    public IActionResult Todos(string title)
    {
        todoRepository.AddTodo(title);
        return todoItemsViewWithFilter();
    }


    [HttpPatch]
    [Route("Todo/Todos/{id}/toggle")]
    public IActionResult ToggleTodo(int id)
    {
        todoRepository.ToggleTodo(id);
        return todoItemsViewWithFilter();
    }

    [HttpDelete]
    [Route("Todo/Todos/{id}")]
    public IActionResult DeleteTodo(int id)
    {
        todoRepository.DeleteTodo(id);
        return PartialView("DeleteTodo", this.todoRepository.Todos);
    }

    [HttpGet]
    public IActionResult DeleteModal(int id)
    {
        return PartialView("Modal", new Modal()
        {
            Title = "Confirm",
            Content = "Are you sure you want to delete?",
            HtmxRequest = HtmxRequest.hxDelete,
            HtmxUrl = $"Todo/Todos/{id}",
            // Now the line is not clear between view and controller. Maybe that is fine??????
            // Alternative: Create unreusable Modal. Bad in another way
            HtmxTarget = $"#todo-item-{id}"
        });
    }

    [HttpGet]
    [Route("CloseModal")]
    public IActionResult CloseModal()
    {
        return PartialView("ModalClosed");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
