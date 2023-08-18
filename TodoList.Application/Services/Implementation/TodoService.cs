using TodoList.Application.Exeptions;
using TodoList.Application.Models;
using TodoList.Enum;
using TodoList.Models;
using TodoList.Repositories;

namespace TodoList.Application.Services.Implementation
{
    public class TodoService : ITodoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITodoRepository _todoRepository;
        private readonly ICurrentUser _currentUser;

        public TodoService(IUnitOfWork unitOfWork, ITodoRepository todoRepository, ICurrentUser currentUser)
        {
            _unitOfWork = unitOfWork;
            _todoRepository = todoRepository;
            _currentUser = currentUser;
        }
        public int Create(Todo todo)
        {
            ArgumentNullException.ThrowIfNull(todo);

            var newTodo = new Todo
            {
                Id = todo.Id,
                Title = todo.Title,
                Description = todo.Description,
                Status = todo.Status,
                UserId = _currentUser.Id,
                CreatedDate = DateTime.UtcNow
            };

            _todoRepository.Add(newTodo);
            _unitOfWork.SaveChanges();
            return newTodo.Id;
        }

        public void Delete(int id)
        {
            var todo = _todoRepository.Get(id);
            if (todo == null || todo.UserId != _currentUser.Id)
            {
                throw new NotFoundException($"Todo with id {id} not found.");
            }

            _todoRepository.Remove(todo);
            _unitOfWork.SaveChanges();
        }

        public Todo GetTodo(int id)
        {
            var todo = _todoRepository.Get(id);
            if (todo == null || todo.UserId != _currentUser.Id)
            {
                throw new NotFoundException($"Todo with id {id} not found.");
            }

            return todo;
        }

        public IEnumerable<Todo> GetTodos()
        {
            return _todoRepository.GetAll(_currentUser.Id);
        }

        public void Update(UpdateTodoCommand todo)
        {
            var todoFromDb = _todoRepository.Get(todo.Id);
            if (todo == null || todoFromDb.UserId != _currentUser.Id)
            {
                throw new NotFoundException($"Todo not found.");
            }

            todoFromDb.Title = todo.Title;
            todoFromDb.Description = todo.Description;

            _todoRepository.Update(todoFromDb);
            _unitOfWork.SaveChanges();
        }

        public void Update(int id, Status status)
        {
            var todo = _todoRepository.Get(id);
            if (todo == null || todo.UserId != _currentUser.Id)
            {
                throw new NotFoundException($"Todo with id {id} not found.");
            }

            todo.Status = status;

            _todoRepository.Update(todo);
            _unitOfWork.SaveChanges();
        }
    }
}
