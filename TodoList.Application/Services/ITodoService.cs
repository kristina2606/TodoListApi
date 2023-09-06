using TodoList.Application.Models;
using TodoList.Models;
using TodoList.Models.Enum;

namespace TodoList.Application.Services
{
    public interface ITodoService
    {
        Task<IEnumerable<Todo>> GetTodosAsync();
        Task<Todo> GetTodoAsync(int id);
        Task DeleteAsync(int id);
        Task<int> CreateAsync(UpdateTodoCommand todo);
        Task UpdateAsync(UpdateTodoCommand todo);
        Task UpdateAsync(int id, Status status);
    }
}
