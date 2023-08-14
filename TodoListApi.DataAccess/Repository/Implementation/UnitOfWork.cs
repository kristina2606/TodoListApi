using TodoListApi.Data;

namespace TodoListApi.Repository.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public ITodoRepository Todo { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Todo = new TodoRepository(_db);
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
