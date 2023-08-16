namespace TodoList.Models
{
    public class UpdateTodoCommand
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
