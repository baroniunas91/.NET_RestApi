using Microsoft.EntityFrameworkCore.Migrations;

namespace RestApiHomework.Asp.Net.Migrations
{
    public partial class addTypeColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "BoughtItems",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "BoughtItems");
        }
    }
}
