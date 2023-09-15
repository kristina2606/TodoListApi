using Microsoft.EntityFrameworkCore;
using TodoList.Application.Repositories;
using TodoList.Models;
using TodoList.Models.Enum;
using TodoList.Persistence.Data;

namespace TodoList.Persistence.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ApplicationDbContext _db;

        public TodoRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Todo todo)
        {
            await _db.Todos.AddAsync(todo);
        }

        public async Task<IEnumerable<Todo>> GetAllAsync(int userId, Status[] statuses)
        {
            if (statuses != null && statuses.Any())
            {
                return await _db.Todos.Where(x => x.UserId == userId && statuses.Contains(x.Status)).ToListAsync();
            }
            else
            {
                return await _db.Todos.Where(x => x.UserId == userId).ToListAsync();
            }
        }

        public async Task<Todo> GetAsync(int todoId)
        {
            return await _db.Todos.FirstOrDefaultAsync(x => x.Id == todoId);
        }

        public async Task RemoveAsync(Todo todo)
        {
            _db.Todos.Remove(todo);
        }

        public async Task UpdateAsync(Todo todo)
        {
            _db.Todos.Update(todo);
        }
    }
}
