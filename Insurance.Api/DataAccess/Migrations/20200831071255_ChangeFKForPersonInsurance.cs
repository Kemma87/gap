using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class ChangeFKForPersonInsurance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonInsurances_InsurancePolicies_PersonId",
                table: "PersonInsurances");

            migrationBuilder.CreateIndex(
                name: "IX_PersonInsurances_InsuranceId",
                table: "PersonInsurances",
                column: "InsuranceId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonInsurances_InsurancePolicies_InsuranceId",
                table: "PersonInsurances",
                column: "InsuranceId",
                principalTable: "InsurancePolicies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonInsurances_InsurancePolicies_InsuranceId",
                table: "PersonInsurances");

            migrationBuilder.DropIndex(
                name: "IX_PersonInsurances_InsuranceId",
                table: "PersonInsurances");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonInsurances_InsurancePolicies_PersonId",
                table: "PersonInsurances",
                column: "PersonId",
                principalTable: "InsurancePolicies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
