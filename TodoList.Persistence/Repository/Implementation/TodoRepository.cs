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
            _db.Set<Todo>().Add(todo);
        }

        public Todo Get(int todoId)
        {
            return _db.Set<Todo>().FirstOrDefault(x => x.Id == todoId);
        }

        public IEnumerable<Todo> GetAll(int userId)
        {
            return _db.Set<Todo>().Where(x => x.UserId == userId);
        }

        public void Remove(Todo todo)
        {
            _db.Set<Todo>().Remove(todo);
        }

        public void Update(Todo todo)
        {
            _db.Set<Todo>().Update(todo);
        }
    }
}
