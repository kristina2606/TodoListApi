namespace TodoListApi.Application
{
    public class CurrentUserProvider : ICurrentUser
    {
        public int Id => 99;

        public string Name => "Test User";

        public string Email => "test_user@example.com";
    }
}
