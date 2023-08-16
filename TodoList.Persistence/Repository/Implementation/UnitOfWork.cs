using TodoList.Data;

namespace TodoList.Repository.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
