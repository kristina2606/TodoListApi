using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoList.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MergeMainInCurrentBranch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 18, 42, 49, 977, DateTimeKind.Local).AddTicks(9169));

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 11, 18, 42, 49, 977, DateTimeKind.Local).AddTicks(9246));

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 19, 18, 42, 49, 977, DateTimeKind.Local).AddTicks(9255));

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2023, 9, 19, 17, 22, 49, 977, DateTimeKind.Local).AddTicks(9264), "93" });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 17, 18, 42, 49, 977, DateTimeKind.Local).AddTicks(9269));

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2023, 9, 16, 18, 42, 49, 977, DateTimeKind.Local).AddTicks(9375), "9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 18, 19, 20, 2, 502, DateTimeKind.Local).AddTicks(6457));

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 10, 19, 20, 2, 502, DateTimeKind.Local).AddTicks(6522));

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 18, 19, 20, 2, 502, DateTimeKind.Local).AddTicks(6529));

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2023, 9, 18, 18, 0, 2, 502, DateTimeKind.Local).AddTicks(6536), "99" });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 16, 19, 20, 2, 502, DateTimeKind.Local).AddTicks(6540));

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2023, 9, 15, 19, 20, 2, 502, DateTimeKind.Local).AddTicks(6542), "99" });
        }
    }
}
