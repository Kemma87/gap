using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddedSeedings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoveringPercentage",
                table: "CoverTypes");

            migrationBuilder.AddColumn<int>(
                name: "CoverPercentage",
                table: "CoverTypes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverPercentage",
                table: "CoverTypes");

            migrationBuilder.AddColumn<int>(
                name: "CoveringPercentage",
                table: "CoverTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
