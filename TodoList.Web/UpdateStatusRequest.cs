using TodoList.Models.Enum;

namespace TodoList.Web
{
    public class UpdateStatusRequest
    {
        public int TodoId { get; set; }
        public string Status { get; set; }
    }

}
