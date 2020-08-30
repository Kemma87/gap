using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class UpdateCoveringPeriodToCoverPeriod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoveringPeriod",
                table: "InsurancePolicies");

            migrationBuilder.AddColumn<byte>(
                name: "CoverPeriod",
                table: "InsurancePolicies",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverPeriod",
                table: "InsurancePolicies");

            migrationBuilder.AddColumn<byte>(
                name: "CoveringPeriod",
                table: "InsurancePolicies",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
