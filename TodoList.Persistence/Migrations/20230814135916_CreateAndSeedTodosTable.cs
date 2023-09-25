using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TodoList.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateAndSeedTodosTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Todos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "CreatedAt", "Description", "Status", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 14, 15, 59, 16, 11, DateTimeKind.Local).AddTicks(966), "Make yourself a balanced breakfast including proteins, carbohydrates, and vitamins. For instance, an omelette with vegetables and a slice of bread.", 1, "Prepare Breakfast" },
                    { 2, new DateTime(2023, 8, 6, 15, 59, 16, 11, DateTimeKind.Local).AddTicks(1073), "Dedicate some time to physical exercises. It will help awaken your body, improve your mood, and get you ready for the day.", 2, "Morning Workout" },
                    { 3, new DateTime(2023, 6, 14, 15, 59, 16, 11, DateTimeKind.Local).AddTicks(1084), "Check your email and respond to important messages. This will help you stay connected with colleagues, friends, and partners", 3, "Respond to Emails" },
                    { 4, new DateTime(2023, 8, 14, 14, 39, 16, 11, DateTimeKind.Local).AddTicks(1093), "Create a task list for the day and prioritize them. This will help you organize your work and achieve your goals.", 1, "Plan Your Work Day" },
                    { 5, new DateTime(2023, 8, 12, 15, 59, 16, 11, DateTimeKind.Local).AddTicks(1098), "Engage in your main tasks according to the list. Avoid distractions and try to focus on one task at a time.", 1, "Productive Work Time" },
                    { 6, new DateTime(2023, 8, 11, 15, 59, 16, 11, DateTimeKind.Local).AddTicks(1100), "Take a break and have lunch. Consider healthy eating, including vegetables, proteins, and healthy fats.", 1, "Lunch Break" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Todos");
        }
    }
}
