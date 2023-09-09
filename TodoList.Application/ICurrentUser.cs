namespace TodoList.Application
{
    public interface ICurrentUser
    {
        string Id { get; }
        string Name { get; }
        string Email { get; }
    }
}
