using TodoHtmx.Web.Models;

namespace TodoHtmx.Web.ViewModels
{
    public class TodoItemViewModel
    {
        public TodoItem TodoItem { get; set; } = new TodoItem();
        public TodoFilterMode Filter { get; set; }
    }
}