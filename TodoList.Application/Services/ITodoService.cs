using TodoList.Application.Models;
using TodoList.Enum;
using TodoList.Models;

namespace TodoList.Application.Services
{
    public interface ITodoService
    {
        Task<IEnumerable<Todo>> GetTodosAsync();
        Task<Todo> GetTodoAsync(int id);
        Task DeleteAsync(int id);
        Task<int> CreateAsync(Todo todo);
        Task UpdateAsync(UpdateTodoCommand todo);
        Task UpdateAsync(int id, Status status);
    }
}
