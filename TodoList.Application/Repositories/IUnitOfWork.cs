namespace TodoList.Application.Repositories
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}
