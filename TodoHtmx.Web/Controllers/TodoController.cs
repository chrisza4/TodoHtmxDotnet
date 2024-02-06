using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TodoHtmx.Web.Models;
using TodoHtmx.Web.Repositories;

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

    public IActionResult TodoItems() {
        return PartialView(this.todoRepository.Todos);
    }

    [HttpPost]
    public IActionResult Todos(string title) {
        todoRepository.AddTodo(title);
        return PartialView("TodoItems", this.todoRepository.Todos);
    }

    [HttpDelete]
    [Route("Todo/Todos")]
    public IActionResult DeleteTodo(int id) {
        todoRepository.DeleteTodo(id);
        return PartialView("DeleteTodo", this.todoRepository.Todos);
    } 

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
