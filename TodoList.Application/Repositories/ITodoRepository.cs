using TodoList.Models;

namespace TodoList.Application.Repositories
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> GetAllAsync(string userId);
        Task<Todo> GetAsync(int todoId);
        Task AddAsync(Todo todo);
        Task RemoveAsync(Todo todo);
        Task UpdateAsync(Todo todo);
    }
}
