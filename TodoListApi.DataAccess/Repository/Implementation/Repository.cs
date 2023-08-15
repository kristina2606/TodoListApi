using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TodoListApi.Data;

namespace TodoListApi.Repository.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Add(T entity)
        {
            _db.Set<T>().Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter, bool tracked = true)
        {
            IQueryable<T> query;

            if (tracked)
            {
                query = _db.Set<T>();
            }
            else
            {
                query = _db.Set<T>().AsNoTracking();
            }

            return query.Where(filter).FirstOrDefault();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter)
        {
            if (filter != null)
            {
                return _db.Set<T>().Where(filter);
            }

            return _db.Set<T>().ToList();
        }

        public void Remove(T entity)
        {
            _db.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _db.Set<T>().Update(entity);
        }
    }
}
