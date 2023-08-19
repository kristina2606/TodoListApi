using TodoList.Models;

namespace TodoList.Application.Repositories
{
    public interface ITodoRepository
    {
        IEnumerable<Todo> GetAll(int userId);
        Todo Get(int todoId);
        void Add(Todo todo);
        void Remove(Todo todo);
        void Update(Todo todo);
    }
}
