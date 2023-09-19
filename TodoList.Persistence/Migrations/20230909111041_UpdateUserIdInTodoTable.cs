using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoList.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserIdInTodoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 9, 13, 10, 41, 383, DateTimeKind.Local).AddTicks(4274));

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 1, 13, 10, 41, 383, DateTimeKind.Local).AddTicks(4407));

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 9, 13, 10, 41, 383, DateTimeKind.Local).AddTicks(4422));

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2023, 9, 9, 11, 50, 41, 383, DateTimeKind.Local).AddTicks(4438), 99 });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 7, 13, 10, 41, 383, DateTimeKind.Local).AddTicks(4447));

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2023, 9, 6, 13, 10, 41, 383, DateTimeKind.Local).AddTicks(4454), 99 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 8, 11, 24, 54, 810, DateTimeKind.Local).AddTicks(6622));

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 31, 11, 24, 54, 810, DateTimeKind.Local).AddTicks(6691));

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 8, 11, 24, 54, 810, DateTimeKind.Local).AddTicks(6698));

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2023, 9, 8, 10, 4, 54, 810, DateTimeKind.Local).AddTicks(6705), 93 });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 6, 11, 24, 54, 810, DateTimeKind.Local).AddTicks(6709));

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2023, 9, 5, 11, 24, 54, 810, DateTimeKind.Local).AddTicks(6712), 9 });
        }
    }
}
