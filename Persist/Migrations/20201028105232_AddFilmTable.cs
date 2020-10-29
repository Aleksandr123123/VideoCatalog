using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persist.Migrations
{
    public partial class AddFilmTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    YearManufacture = table.Column<DateTimeOffset>(nullable: false),
                    Poster = table.Column<string>(nullable: true),
                    RegisseurId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Films_Regisseurs_RegisseurId",
                        column: x => x.RegisseurId,
                        principalTable: "Regisseurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Films_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Films_RegisseurId",
                table: "Films",
                column: "RegisseurId");

            migrationBuilder.CreateIndex(
                name: "IX_Films_UserId",
                table: "Films",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Films");
        }
    }
}
