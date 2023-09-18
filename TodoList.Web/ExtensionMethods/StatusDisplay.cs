using TodoList.Models.Enum;

namespace TodoList.Web.ExtensionMethods
{
    public static class StatusDisplay
    {
        public static string ToDisplayName(this Status status)
        {
            return status switch
            {
                Status.Completed => "Completed",
                Status.InProgress => "In Progress",
                Status.Todo => "Todo",
                _ => status.ToString(),
            };
        }
    }
}
