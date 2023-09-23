using TodoList.Application.Enums;
using TodoList.Application.Exeptions;
using TodoList.Application.Extension;
using TodoList.Application.Models;
using TodoList.Application.Repositories;
using TodoList.Models;
using TodoList.Models.Enum;

namespace TodoList.Application.Services.Implementation
{
    public class TodoService : ITodoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITodoRepository _todoRepository;
        private readonly ICurrentUser _currentUser;

        public TodoService(ITodoRepository todoRepository, ICurrentUser currentUser, IUnitOfWork unitOfWork)
        {
            _todoRepository = todoRepository;
            _currentUser = currentUser;
            _unitOfWork = unitOfWork;
        }
        public async Task<int> CreateAsync(CreateTodoCommand todo)
        {
            ArgumentNullException.ThrowIfNull(todo);

            var newTodo = new Todo
            {
                Title = todo.Title,
                Description = todo.Description,
                Status = Status.Todo,
                UserId = _currentUser.Id,
                CreatedAt = DateTime.UtcNow
            };

            await _todoRepository.AddAsync(newTodo);
            await _unitOfWork.SaveChangesAsync();

            return newTodo.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var todo = await _todoRepository.GetAsync(id);
            if (todo == null || todo.UserId != _currentUser.Id)
            {
                throw new NotFoundException($"Todo with id {id} not found.");
            }

            await _todoRepository.RemoveAsync(todo);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<Todo> GetTodoAsync(int id)
        {
            var todo = await _todoRepository.GetAsync(id);
            if (todo == null || todo.UserId != _currentUser.Id)
            {
                throw new NotFoundException($"Todo with id {id} not found.");
            }

            return todo;
        }

        public async Task<IEnumerable<Todo>> GetTodosAsync(FilterStatus status)
        {
            var statuses = status.ToTodoStatus();

            return await _todoRepository.GetAllAsync(_currentUser.Id, statuses);
        }


        public async Task UpdateAsync(UpdateTodoCommand todo)
        {
            var todoFromDb = await _todoRepository.GetAsync(todo.Id);
            if (todo == null || todoFromDb.UserId != _currentUser.Id)
            {
                throw new NotFoundException($"Todo not found.");
            }

            todoFromDb.Title = todo.Title;
            todoFromDb.Description = todo.Description;

            await _todoRepository.UpdateAsync(todoFromDb);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, Status status)
        {
            var todo = await _todoRepository.GetAsync(id);
            if (todo == null || todo.UserId != _currentUser.Id)
            {
                throw new NotFoundException($"Todo with id {id} not found.");
            }

            todo.Status = status;

            await _todoRepository.UpdateAsync(todo);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
