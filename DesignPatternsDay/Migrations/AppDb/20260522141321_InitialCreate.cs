using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignPatternsDay.Migrations.AppDb
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    IsOrganic = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "CreatedAt", "IsOrganic", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, "Vegetables", new DateTime(2026, 5, 22, 17, 13, 21, 761, DateTimeKind.Local).AddTicks(9613), true, "Organic Cabbage", 50m, 100 },
                    { 2, "Meats", new DateTime(2026, 5, 22, 17, 13, 21, 761, DateTimeKind.Local).AddTicks(9623), false, "Beef Steak", 150m, 30 },
                    { 3, "Beverages", new DateTime(2026, 5, 22, 17, 13, 21, 761, DateTimeKind.Local).AddTicks(9624), true, "Mango Juice", 25m, 5 },
                    { 4, "Vegetables", new DateTime(2026, 5, 22, 17, 13, 21, 761, DateTimeKind.Local).AddTicks(9625), true, "Broccoli", 35m, 80 },
                    { 5, "Fruits", new DateTime(2026, 5, 22, 17, 13, 21, 761, DateTimeKind.Local).AddTicks(9625), false, "Strawberries", 45m, 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
