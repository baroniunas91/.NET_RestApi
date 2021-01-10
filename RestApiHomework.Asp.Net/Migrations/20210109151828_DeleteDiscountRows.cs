using Microsoft.EntityFrameworkCore.Migrations;

namespace RestApiHomework.Asp.Net.Migrations
{
    public partial class DeleteDiscountRows : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount1",
                table: "Vegetables");

            migrationBuilder.DropColumn(
                name: "Discount2",
                table: "Vegetables");

            migrationBuilder.DropColumn(
                name: "Discount1",
                table: "Fruits");

            migrationBuilder.DropColumn(
                name: "Discount2",
                table: "Fruits");

            migrationBuilder.DropColumn(
                name: "Discount1",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "Discount2",
                table: "Dishes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Discount1",
                table: "Vegetables",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Discount2",
                table: "Vegetables",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Discount1",
                table: "Fruits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Discount2",
                table: "Fruits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Discount1",
                table: "Dishes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Discount2",
                table: "Dishes",
                type: "int",
                nullable: true);
        }
    }
}
