using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignPatternsDay.Migrations.AppDb
{
    public partial class FixDecimalPrecision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 22, 17, 15, 8, 379, DateTimeKind.Local).AddTicks(211));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 22, 17, 15, 8, 379, DateTimeKind.Local).AddTicks(225));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 22, 17, 15, 8, 379, DateTimeKind.Local).AddTicks(227));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 22, 17, 15, 8, 379, DateTimeKind.Local).AddTicks(228));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 22, 17, 15, 8, 379, DateTimeKind.Local).AddTicks(228));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 22, 17, 13, 21, 761, DateTimeKind.Local).AddTicks(9613));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 22, 17, 13, 21, 761, DateTimeKind.Local).AddTicks(9623));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 22, 17, 13, 21, 761, DateTimeKind.Local).AddTicks(9624));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 22, 17, 13, 21, 761, DateTimeKind.Local).AddTicks(9625));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 22, 17, 13, 21, 761, DateTimeKind.Local).AddTicks(9625));
        }
    }
}
