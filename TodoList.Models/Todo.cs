using System.ComponentModel.DataAnnotations;
using TodoList.Models.Enum;

namespace TodoList.Models
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
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
    }
}
