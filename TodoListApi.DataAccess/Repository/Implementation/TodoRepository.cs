using TodoListApi.Data;
using TodoListApi.Models;

namespace TodoListApi.Repository.Implementation
{
    public class TodoRepository : Repository<Todo>, ITodoRepository
    {
        public TodoRepository(ApplicationDbContext db)
            : base(db)
        {
        }
    }
}
