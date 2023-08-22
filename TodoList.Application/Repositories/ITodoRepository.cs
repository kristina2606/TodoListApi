using TodoList.Models;

namespace TodoList.Application.Repositories
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> GetAllAsync(int userId);
        Task<Todo> GetAsync(int todoId);
        Task AddAsync(Todo todo);
        void Remove(Todo todo);
        void Update(Todo todo);
    }
}
