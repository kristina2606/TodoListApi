using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoList.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserIdToStringInTodoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Todos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UserId" },
                values: new object[] { new DateTime(2023, 9, 9, 13, 20, 25, 359, DateTimeKind.Local).AddTicks(3384), "99" });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UserId" },
                values: new object[] { new DateTime(2023, 9, 1, 13, 20, 25, 359, DateTimeKind.Local).AddTicks(3503), "99" });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UserId" },
                values: new object[] { new DateTime(2023, 7, 9, 13, 20, 25, 359, DateTimeKind.Local).AddTicks(3512), "99" });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UserId" },
                values: new object[] { new DateTime(2023, 9, 9, 12, 0, 25, 359, DateTimeKind.Local).AddTicks(3522), "99" });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UserId" },
                values: new object[] { new DateTime(2023, 9, 7, 13, 20, 25, 359, DateTimeKind.Local).AddTicks(3526), "99" });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UserId" },
                values: new object[] { new DateTime(2023, 9, 6, 13, 20, 25, 359, DateTimeKind.Local).AddTicks(3529), "99" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Todos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UserId" },
                values: new object[] { new DateTime(2023, 9, 9, 13, 10, 41, 383, DateTimeKind.Local).AddTicks(4274), 99 });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UserId" },
                values: new object[] { new DateTime(2023, 9, 1, 13, 10, 41, 383, DateTimeKind.Local).AddTicks(4407), 99 });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UserId" },
                values: new object[] { new DateTime(2023, 7, 9, 13, 10, 41, 383, DateTimeKind.Local).AddTicks(4422), 99 });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UserId" },
                values: new object[] { new DateTime(2023, 9, 9, 11, 50, 41, 383, DateTimeKind.Local).AddTicks(4438), 99 });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UserId" },
                values: new object[] { new DateTime(2023, 9, 7, 13, 10, 41, 383, DateTimeKind.Local).AddTicks(4447), 99 });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UserId" },
                values: new object[] { new DateTime(2023, 9, 6, 13, 10, 41, 383, DateTimeKind.Local).AddTicks(4454), 99 });
        }
    }
}
