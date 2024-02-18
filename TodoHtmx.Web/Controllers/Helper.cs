using TodoHtmx.Web.Models;

namespace TodoHtmx.Web.Controllers;

public class RequestHelper
{
    public static TodoFilterMode TodoFilterModeFromQueryString(string queryString)
    {
        switch (queryString)
        {
            case "active": return TodoFilterMode.Active;
            case "completed": return TodoFilterMode.Completed;
            default: return TodoFilterMode.All;
        }
    }
}