using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment5_wellingJ.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumPages",
                table: "Libraries",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumPages",
                table: "Libraries");
        }
    }
}
