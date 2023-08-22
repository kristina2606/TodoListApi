using Microsoft.EntityFrameworkCore;
using TodoList.Models;
using TodoList.Models.Enum;

namespace TodoList.Persistence.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Todo>().HasData(
                new Todo { Id = 1, Title = "Prepare Breakfast", Description = "Make yourself a balanced breakfast including proteins, carbohydrates, and vitamins. For instance, an omelette with vegetables and a slice of bread.", Status = Status.Todo, CreatedDate = DateTime.Now, UserId = 99 },
                new Todo { Id = 2, Title = "Morning Workout", Description = "Dedicate some time to physical exercises. It will help awaken your body, improve your mood, and get you ready for the day.", Status = Status.InProgress, CreatedDate = DateTime.Now.AddDays(-8), UserId = 99 },
                new Todo { Id = 3, Title = "Respond to Emails", Description = "Check your email and respond to important messages. This will help you stay connected with colleagues, friends, and partners", Status = Status.Completed, CreatedDate = DateTime.Now.AddMonths(-2), UserId = 99 },
                new Todo { Id = 4, Title = "Plan Your Work Day", Description = "Create a task list for the day and prioritize them. This will help you organize your work and achieve your goals.", Status = Status.Todo, CreatedDate = DateTime.Now.AddMinutes(-80), UserId = 93 },
                new Todo { Id = 5, Title = "Productive Work Time", Description = "Engage in your main tasks according to the list. Avoid distractions and try to focus on one task at a time.", Status = Status.Todo, CreatedDate = DateTime.Now.AddDays(-2), UserId = 99 },
                new Todo { Id = 6, Title = "Lunch Break", Description = "Take a break and have lunch. Consider healthy eating, including vegetables, proteins, and healthy fats.", Status = Status.Todo, CreatedDate = DateTime.Now.AddDays(-3), UserId = 9 }
                );
        }

    }
}
