using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TODO.Migrations
{
    /// <inheritdoc />
    public partial class TodoComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TodoComments",
                columns: table => new
                {
                    CommentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserTodoCommentForeignKey = table.Column<string>(type: "TEXT", nullable: true),
                    CommentName = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoComments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_TodoComments_AspNetUsers_UserTodoCommentForeignKey",
                        column: x => x.UserTodoCommentForeignKey,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TodoComments_UserTodoCommentForeignKey",
                table: "TodoComments",
                column: "UserTodoCommentForeignKey");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoComments");
        }
    }
}
