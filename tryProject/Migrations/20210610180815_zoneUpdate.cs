using Microsoft.EntityFrameworkCore.Migrations;

namespace tryProject.Migrations
{
    public partial class zoneUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "spName",
                table: "Zone",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "spName",
                table: "Zone");
        }
    }
}
