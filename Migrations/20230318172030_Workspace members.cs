using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TODO.Migrations
{
    /// <inheritdoc />
    public partial class Workspacemembers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Board_AspNetUsers_UserBoardForeignKey",
                table: "Board");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_Board_BoardId",
                table: "TodoItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Board",
                table: "Board");

            migrationBuilder.RenameTable(
                name: "Board",
                newName: "Boards");

            migrationBuilder.RenameIndex(
                name: "IX_Board_UserBoardForeignKey",
                table: "Boards",
                newName: "IX_Boards_UserBoardForeignKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Boards",
                table: "Boards",
                column: "BoardId");

            migrationBuilder.CreateTable(
                name: "Workspaces",
                columns: table => new
                {
                    WorkspaceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserTodoItemForeignKey = table.Column<string>(type: "TEXT", nullable: true),
                    IsCompleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workspaces", x => x.WorkspaceId);
                    table.ForeignKey(
                        name: "FK_Workspaces_AspNetUsers_UserTodoItemForeignKey",
                        column: x => x.UserTodoItemForeignKey,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WorkspacesMembers",
                columns: table => new
                {
                    WorkspaceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId1 = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkspacesMembers", x => new { x.WorkspaceId, x.UserId });
                    table.ForeignKey(
                        name: "FK_WorkspacesMembers_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkspacesMembers_Workspaces_WorkspaceId",
                        column: x => x.WorkspaceId,
                        principalTable: "Workspaces",
                        principalColumn: "WorkspaceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workspaces_UserTodoItemForeignKey",
                table: "Workspaces",
                column: "UserTodoItemForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_WorkspacesMembers_UserId1",
                table: "WorkspacesMembers",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Boards_AspNetUsers_UserBoardForeignKey",
                table: "Boards",
                column: "UserBoardForeignKey",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_Boards_BoardId",
                table: "TodoItems",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "BoardId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boards_AspNetUsers_UserBoardForeignKey",
                table: "Boards");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_Boards_BoardId",
                table: "TodoItems");

            migrationBuilder.DropTable(
                name: "WorkspacesMembers");

            migrationBuilder.DropTable(
                name: "Workspaces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Boards",
                table: "Boards");

            migrationBuilder.RenameTable(
                name: "Boards",
                newName: "Board");

            migrationBuilder.RenameIndex(
                name: "IX_Boards_UserBoardForeignKey",
                table: "Board",
                newName: "IX_Board_UserBoardForeignKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Board",
                table: "Board",
                column: "BoardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Board_AspNetUsers_UserBoardForeignKey",
                table: "Board",
                column: "UserBoardForeignKey",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_Board_BoardId",
                table: "TodoItems",
                column: "BoardId",
                principalTable: "Board",
                principalColumn: "BoardId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
