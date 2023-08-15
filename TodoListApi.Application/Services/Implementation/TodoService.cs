using TodoListApi.Application.Exeptions;
using TodoListApi.Models;
using TodoListApi.Repository;

namespace TodoListApi.Application.Services.Implementation
{
    public class TodoService : ITodoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUser _user;

        public TodoService(IUnitOfWork unitOfWork, ICurrentUser user)
        {
            _unitOfWork = unitOfWork;
            _user = user;
        }
        public int Create(Todo todo)
        {
            if (todo == null)
            {
                throw new ArgumentNullException(nameof(todo));
            }

            var newTodo = new Todo
            {
                Id = todo.Id,
                Title = todo.Title,
                Description = todo.Description,
                Status = todo.Status,
                UserId = _user.Id,
                CreatedDate = DateTime.Now
            };

            _unitOfWork.Todo.Add(newTodo);
            _unitOfWork.SaveChanges();
            return newTodo.Id;
        }

        public void Delete(int id)
        {
            var todo = _unitOfWork.Todo.Get(x => x.Id == id && x.UserId == _user.Id);
            if (todo == null)
            {
                throw new NotFoundException($"Todo with id {id} not found.");
            }
            _unitOfWork.Todo.Remove(todo);
            _unitOfWork.SaveChanges();
        }

        public Todo GetTodo(int id)
        {
            var todo = _unitOfWork.Todo.Get(x => x.Id == id && x.UserId == _user.Id);
            return todo ?? throw new NotFoundException($"Todo with id {id} not found.");
        }

        public IEnumerable<Todo> GetTodos()
        {
            return _unitOfWork.Todo.GetAll(x => x.UserId == _user.Id);
        }

        public void Update(int id)
        {
            var todo = _unitOfWork.Todo.Get(x => x.Id == id && x.UserId == _user.Id);
            if (todo == null)
            {
                throw new NotFoundException($"Todo with id {id} not found.");
            }
            _unitOfWork.Todo.Update(todo);
            _unitOfWork.SaveChanges();
        }
    }
}
