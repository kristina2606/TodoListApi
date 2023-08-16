using TodoList.Application.Models;
using TodoList.Enum;
using TodoList.Models;

namespace TodoList.Application.Services
{
    public interface ITodoService
    {
        IEnumerable<Todo> GetTodos();
        Todo GetTodo(int id);
        void Delete(int id);
        int Create(Todo todo);
        void Update(UpdateTodoCommand todo);
        void Update(int id, Status status);
    }
}
