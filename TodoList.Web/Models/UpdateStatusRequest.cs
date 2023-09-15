using TodoList.Models.Enum;

namespace TodoList.Web.Models
{
    public class UpdateStatusRequest
    {
        public int TodoId { get; set; }
        public Status Status { get; set; }
    }
}
