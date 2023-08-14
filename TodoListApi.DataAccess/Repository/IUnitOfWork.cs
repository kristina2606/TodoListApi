namespace TodoListApi.Repository
{
    public interface IUnitOfWork
    {
        ITodoRepository Todo { get; }
        void SaveChanges();
    }
}
