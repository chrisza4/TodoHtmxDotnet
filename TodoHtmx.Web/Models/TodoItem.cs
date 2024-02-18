namespace TodoHtmx.Web.Models;

public class TodoItem
{
    public int Id;
    public string Title = "";

    public bool IsCompleted = false;
}

public enum TodoFilterMode
{
    All, Active, Completed
}
