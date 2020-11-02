using Microsoft.EntityFrameworkCore.Migrations;

namespace Persist.Migrations
{
    public partial class AddYearManufactureInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "YearManufacture",
                table: "Films",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YearManufacture",
                table: "Films");
        }
    }
}
