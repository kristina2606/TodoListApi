namespace TodoList.Application.Repositories
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
