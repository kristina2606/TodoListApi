using TodoList.Models;
using TodoList.Models.Enum;

namespace TodoList.Application.Repositories
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> GetAllAsync(int userId, Status[] statuses);
        Task<Todo> GetAsync(int todoId);
        Task AddAsync(Todo todo);
        Task RemoveAsync(Todo todo);
        Task UpdateAsync(Todo todo);
    }
}
