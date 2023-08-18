using TodoList.Models;

namespace TodoList.Repository
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> GetAllAsync(int userId);
        Task<Todo> GetAsync(int todoId);
        Task AddAsync(Todo todo);
        Task RemoveAsync(Todo todo);
        Task UpdateAsync(Todo todo);
    }
}
