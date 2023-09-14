namespace TodoList.Web.Models
{
    public class UpdateStatusRequest
    {
        public int TodoId { get; set; }
        public string Status { get; set; }
    }
}
