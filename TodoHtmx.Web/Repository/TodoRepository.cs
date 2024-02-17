using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoHtmx.Web.Models;

namespace TodoHtmx.Web.Repositories
{
    public class TodoRepository
    {
        public TodoRepository()
        {

        }
        private List<TodoItem> todos = new List<TodoItem>() {
            new TodoItem() {
                Id=0, Title="Initial todo"
            }
        };

        public List<TodoItem> Todos { get => todos; }

        public void AddTodo(string title)
        {
            todos.Add(new TodoItem()
            {
                Id = todos.Count,
                Title = title,
                IsCompleted = false
            });
        }

        public void DeleteTodo(int id)
        {
            var toDelete = todos.First(c => c.Id == id);
            todos.Remove(toDelete);
        }

        public void ToggleTodo(int id)
        {
            var toEdit = todos.First(c => c.Id == id);
            toEdit.IsCompleted = !toEdit.IsCompleted;
        }
    }
}
