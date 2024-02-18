using TodoHtmx.Web.Models;

namespace TodoHtmx.Web.ViewModels
{
    public class TodoItemsViewModel
    {
        public List<TodoItem> TodoItems { get; set; } = new List<TodoItem>();
        public TodoFilterMode Filter { get; set; }
    }
}