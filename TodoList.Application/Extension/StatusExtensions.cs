using TodoList.Application.Enums;
using TodoList.Models.Enum;

namespace TodoList.Application.Extension
{
    public static class StatusExtensions
    {
        public static Status[] ToTodoStatus(this FilterStatus filterStatus)
        {
            return filterStatus switch
            {
                FilterStatus.All => new Status[] { Status.InProgress, Status.Todo, Status.Completed },
                FilterStatus.Active => new Status[] { Status.InProgress, Status.Todo },
                FilterStatus.Todo => new Status[] { Status.Todo },
                FilterStatus.InProgress => new Status[] { Status.InProgress },
                FilterStatus.Completed => new Status[] { Status.Completed },
                _ => throw new ArgumentException("Invalid filter status."),
            };
        }
    }
}
