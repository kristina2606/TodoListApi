using System.ComponentModel.DataAnnotations;
using TodoListApi.Enum;

namespace TodoListApi.Models
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Title { get; set; }
        public string? Description { get; set; }
        [Required]
        public Status Status { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }
    }
}
