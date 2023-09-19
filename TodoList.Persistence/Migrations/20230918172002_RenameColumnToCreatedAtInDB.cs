using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoList.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumnToCreatedAtInDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Todos",
                newName: "CreatedAt");

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
                column: "CreatedAt",
                value: new DateTime(2023, 9, 18, 18, 0, 2, 502, DateTimeKind.Local).AddTicks(6536));

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
                column: "CreatedAt",
                value: new DateTime(2023, 9, 15, 19, 20, 2, 502, DateTimeKind.Local).AddTicks(6542));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Todos",
                newName: "CreatedAt");

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 9, 18, 45, 48, 221, DateTimeKind.Local).AddTicks(8877));

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 1, 18, 45, 48, 221, DateTimeKind.Local).AddTicks(8997));

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 9, 18, 45, 48, 221, DateTimeKind.Local).AddTicks(9005));

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 9, 17, 25, 48, 221, DateTimeKind.Local).AddTicks(9015));

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 7, 18, 45, 48, 221, DateTimeKind.Local).AddTicks(9020));

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 6, 18, 45, 48, 221, DateTimeKind.Local).AddTicks(9022));
        }
    }
}
