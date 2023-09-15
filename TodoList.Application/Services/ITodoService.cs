using TodoList.Application.Models;
using TodoList.Models;
using TodoList.Models.Enum;
using TodoList.Web.Models.Enum;

namespace TodoList.Application.Services
{
    public interface ITodoService
    {
        Task<IEnumerable<Todo>> GetTodosAsync(FilterStatus? status);
        Task<Todo> GetTodoAsync(int id);
        Task DeleteAsync(int id);
        Task<int> CreateAsync(CreateTodoCommand command);
        Task UpdateAsync(UpdateTodoCommand todo);
        Task UpdateAsync(int id, Status status);
    }
}
