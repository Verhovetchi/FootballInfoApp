using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballInfoApp.API.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StadiumImage",
                table: "Stadiums",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Tour",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StadiumImage",
                table: "Stadiums");

            migrationBuilder.DropColumn(
                name: "Tour",
                table: "Matches");
        }
    }
}
