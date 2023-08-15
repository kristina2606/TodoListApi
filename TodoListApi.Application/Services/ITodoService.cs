using TodoListApi.Models;

namespace TodoListApi.Application.Services
{
    public interface ITodoService
    {
        IEnumerable<Todo> GetTodos();
        Todo GetTodo(int id);
        void Delete(int id);
        void Update(int id);
        int Create(Todo todo);
    }
}
