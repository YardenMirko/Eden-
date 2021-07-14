using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tryProject.Migrations
{
    public partial class yuli : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Volunteer",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "Introduction",
                table: "Association",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Association",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ForumCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ForumCategoryTag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumCategoryTag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Forum",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatePublished = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ForumCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forum", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Forum_ForumCategory_ForumCategoryId",
                        column: x => x.ForumCategoryId,
                        principalTable: "ForumCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ForumId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Forum_ForumId",
                        column: x => x.ForumId,
                        principalTable: "Forum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ForumForumCategoryTag",
                columns: table => new
                {
                    ForumCategoryTagsId = table.Column<int>(type: "int", nullable: false),
                    ForumsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumForumCategoryTag", x => new { x.ForumCategoryTagsId, x.ForumsId });
                    table.ForeignKey(
                        name: "FK_ForumForumCategoryTag_Forum_ForumsId",
                        column: x => x.ForumsId,
                        principalTable: "Forum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ForumForumCategoryTag_ForumCategoryTag_ForumCategoryTagsId",
                        column: x => x.ForumCategoryTagsId,
                        principalTable: "ForumCategoryTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Remark",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentId = table.Column<int>(type: "int", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemarkTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Remark", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Remark_Comment_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ForumId",
                table: "Comment",
                column: "ForumId");

            migrationBuilder.CreateIndex(
                name: "IX_Forum_ForumCategoryId",
                table: "Forum",
                column: "ForumCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumForumCategoryTag_ForumsId",
                table: "ForumForumCategoryTag",
                column: "ForumsId");

            migrationBuilder.CreateIndex(
                name: "IX_Remark_CommentId",
                table: "Remark",
                column: "CommentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ForumForumCategoryTag");

            migrationBuilder.DropTable(
                name: "Remark");

            migrationBuilder.DropTable(
                name: "ForumCategoryTag");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Forum");

            migrationBuilder.DropTable(
                name: "ForumCategory");

            migrationBuilder.DropColumn(
                name: "Introduction",
                table: "Association");

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Association");

            migrationBuilder.AddColumn<bool>(
                name: "Volunteer",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
