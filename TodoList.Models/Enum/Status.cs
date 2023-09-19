using System.ComponentModel.DataAnnotations;

namespace TodoList.Models.Enum
{
    public enum Status
    {
        Todo = 1,
        [Display(Name = "In Progress")]
        InProgress = 2,
        Completed = 3
    }
}
