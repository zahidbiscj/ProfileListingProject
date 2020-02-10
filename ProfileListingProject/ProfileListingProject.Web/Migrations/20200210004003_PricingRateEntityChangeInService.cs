using Microsoft.EntityFrameworkCore.Migrations;

namespace ProfileListingProject.Web.Migrations
{
    public partial class PricingRateEntityChangeInService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PricingRates_CompanyServices_CompanyServiceId",
                table: "PricingRates");

            migrationBuilder.DropIndex(
                name: "IX_PricingRates_CompanyServiceId",
                table: "PricingRates");

            migrationBuilder.DropColumn(
                name: "PricingRate",
                table: "CompanyServices");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyServiceId",
                table: "PricingRates",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PricingRates_CompanyServiceId",
                table: "PricingRates",
                column: "CompanyServiceId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PricingRates_CompanyServices_CompanyServiceId",
                table: "PricingRates",
                column: "CompanyServiceId",
                principalTable: "CompanyServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PricingRates_CompanyServices_CompanyServiceId",
                table: "PricingRates");

            migrationBuilder.DropIndex(
                name: "IX_PricingRates_CompanyServiceId",
                table: "PricingRates");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyServiceId",
                table: "PricingRates",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "PricingRate",
                table: "CompanyServices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PricingRates_CompanyServiceId",
                table: "PricingRates",
                column: "CompanyServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_PricingRates_CompanyServices_CompanyServiceId",
                table: "PricingRates",
                column: "CompanyServiceId",
                principalTable: "CompanyServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
