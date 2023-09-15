using System.ComponentModel.DataAnnotations;

namespace TodoList.Application.Enums
{
    public enum FilterStatus
    {
        All,
        Active,
        Todo,
        [Display(Name = "In Progress")]
        InProgress,
        Completed
    }
}
