using Microsoft.EntityFrameworkCore;
using TodoListApi.Models;

namespace TodoListApi.Data
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
                new Todo { Id = 1, Title = "Prepare Breakfast", Description = "Make yourself a balanced breakfast including proteins, carbohydrates, and vitamins. For instance, an omelette with vegetables and a slice of bread.", Status = Enum.Status.Todo, CreatedDate = DateTime.Now },
                new Todo { Id = 2, Title = "Morning Workout", Description = "Dedicate some time to physical exercises. It will help awaken your body, improve your mood, and get you ready for the day.", Status = Enum.Status.InProcess, CreatedDate = DateTime.Now.AddDays(-8) },
                new Todo { Id = 3, Title = "Respond to Emails", Description = "Check your email and respond to important messages. This will help you stay connected with colleagues, friends, and partners", Status = Enum.Status.Completed, CreatedDate = DateTime.Now.AddMonths(-2) },
                new Todo { Id = 4, Title = "Plan Your Work Day", Description = "Create a task list for the day and prioritize them. This will help you organize your work and achieve your goals.", Status = Enum.Status.Todo, CreatedDate = DateTime.Now.AddMinutes(-80) },
                new Todo { Id = 5, Title = "Productive Work Time", Description = "Engage in your main tasks according to the list. Avoid distractions and try to focus on one task at a time.", Status = Enum.Status.Todo, CreatedDate = DateTime.Now.AddDays(-2) },
                new Todo { Id = 6, Title = "Lunch Break", Description = "Take a break and have lunch. Consider healthy eating, including vegetables, proteins, and healthy fats.", Status = Enum.Status.Todo, CreatedDate = DateTime.Now.AddDays(-3) }
                );
        }

    }
}
