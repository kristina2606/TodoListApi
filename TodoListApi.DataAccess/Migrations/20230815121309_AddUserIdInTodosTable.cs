using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoListApi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdInTodosTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Todos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UserId" },
                values: new object[] { new DateTime(2023, 8, 15, 14, 13, 9, 395, DateTimeKind.Local).AddTicks(9134), 99 });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UserId" },
                values: new object[] { new DateTime(2023, 8, 7, 14, 13, 9, 395, DateTimeKind.Local).AddTicks(9201), 99 });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UserId" },
                values: new object[] { new DateTime(2023, 6, 15, 14, 13, 9, 395, DateTimeKind.Local).AddTicks(9207), 99 });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UserId" },
                values: new object[] { new DateTime(2023, 8, 15, 12, 53, 9, 395, DateTimeKind.Local).AddTicks(9213), 93 });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UserId" },
                values: new object[] { new DateTime(2023, 8, 13, 14, 13, 9, 395, DateTimeKind.Local).AddTicks(9216), 99 });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UserId" },
                values: new object[] { new DateTime(2023, 8, 12, 14, 13, 9, 395, DateTimeKind.Local).AddTicks(9218), 9 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Todos");

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 14, 15, 59, 16, 11, DateTimeKind.Local).AddTicks(966));

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 6, 15, 59, 16, 11, DateTimeKind.Local).AddTicks(1073));

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 14, 15, 59, 16, 11, DateTimeKind.Local).AddTicks(1084));

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 14, 14, 39, 16, 11, DateTimeKind.Local).AddTicks(1093));

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 12, 15, 59, 16, 11, DateTimeKind.Local).AddTicks(1098));

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 11, 15, 59, 16, 11, DateTimeKind.Local).AddTicks(1100));
        }
    }
}
