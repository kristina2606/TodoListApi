using System.Linq.Expressions;

namespace TodoListApi.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> filter, bool tracked = false);
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
    }
}
