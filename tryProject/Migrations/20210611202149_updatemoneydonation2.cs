using Microsoft.EntityFrameworkCore.Migrations;

namespace tryProject.Migrations
{
    public partial class updatemoneydonation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CatersToId",
                table: "MoneyDonation",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MoneyDonation_CatersToId",
                table: "MoneyDonation",
                column: "CatersToId");

            migrationBuilder.AddForeignKey(
                name: "FK_MoneyDonation_CatersTo_CatersToId",
                table: "MoneyDonation",
                column: "CatersToId",
                principalTable: "CatersTo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoneyDonation_CatersTo_CatersToId",
                table: "MoneyDonation");

            migrationBuilder.DropIndex(
                name: "IX_MoneyDonation_CatersToId",
                table: "MoneyDonation");

            migrationBuilder.DropColumn(
                name: "CatersToId",
                table: "MoneyDonation");
        }
    }
}
