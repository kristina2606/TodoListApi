using TodoList.Data;
using TodoList.Models;

namespace TodoList.Repository.Implementation
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ApplicationDbContext _db;

        public TodoRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Add(Todo todo)
        {
            _db.Todos.Add(todo);
        }

        public Todo Get(int todoId)
        {
            return _db.Todos.FirstOrDefault(x => x.Id == todoId);
        }

        public IEnumerable<Todo> GetAll(int userId)
        {
            return _db.Todos.Where(x => x.UserId == userId);
        }

        public void Remove(Todo todo)
        {
            _db.Todos.Remove(todo);
        }

        public void Update(Todo todo)
        {
            _db.Todos.Update(todo);
        }
    }
}
