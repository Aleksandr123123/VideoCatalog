using Microsoft.EntityFrameworkCore.Migrations;

namespace Persist.Migrations
{
    public partial class UpdateYearManufacture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YearManufacture",
                table: "Films");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "YearManufacture",
                table: "Films",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
