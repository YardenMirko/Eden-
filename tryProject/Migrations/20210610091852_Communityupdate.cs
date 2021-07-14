using Microsoft.EntityFrameworkCore.Migrations;

namespace tryProject.Migrations
{
    public partial class Communityupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CatersToId",
                table: "CommunityWorks",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ZoneId",
                table: "CommunityWorks",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CommunityWorks_CatersToId",
                table: "CommunityWorks",
                column: "CatersToId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityWorks_ZoneId",
                table: "CommunityWorks",
                column: "ZoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityWorks_CatersTo_CatersToId",
                table: "CommunityWorks",
                column: "CatersToId",
                principalTable: "CatersTo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityWorks_Zone_ZoneId",
                table: "CommunityWorks",
                column: "ZoneId",
                principalTable: "Zone",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommunityWorks_CatersTo_CatersToId",
                table: "CommunityWorks");

            migrationBuilder.DropForeignKey(
                name: "FK_CommunityWorks_Zone_ZoneId",
                table: "CommunityWorks");

            migrationBuilder.DropIndex(
                name: "IX_CommunityWorks_CatersToId",
                table: "CommunityWorks");

            migrationBuilder.DropIndex(
                name: "IX_CommunityWorks_ZoneId",
                table: "CommunityWorks");

            migrationBuilder.DropColumn(
                name: "CatersToId",
                table: "CommunityWorks");

            migrationBuilder.DropColumn(
                name: "ZoneId",
                table: "CommunityWorks");
        }
    }
}
