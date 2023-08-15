using System.Linq.Expressions;

namespace TodoListApi.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter);
        T Get(Expression<Func<T, bool>> filter, bool tracked = true);
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
    }
}
