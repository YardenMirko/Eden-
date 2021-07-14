using Microsoft.EntityFrameworkCore.Migrations;

namespace tryProject.Migrations
{
    public partial class updatemoneydonation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Decscription",
                table: "MoneyDonation",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Decscription",
                table: "MoneyDonation");
        }
    }
}
