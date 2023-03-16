using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TODO.Migrations
{
    /// <inheritdoc />
    public partial class Addboardtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BoardId",
                table: "TodoItems",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Board",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserBoardForeignKey = table.Column<string>(type: "TEXT", nullable: true),
                    BoardName = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Board", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Board_AspNetUsers_UserBoardForeignKey",
                        column: x => x.UserBoardForeignKey,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_BoardId",
                table: "TodoItems",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Board_UserBoardForeignKey",
                table: "Board",
                column: "UserBoardForeignKey");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_Board_BoardId",
                table: "TodoItems",
                column: "BoardId",
                principalTable: "Board",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_Board_BoardId",
                table: "TodoItems");

            migrationBuilder.DropTable(
                name: "Board");

            migrationBuilder.DropIndex(
                name: "IX_TodoItems_BoardId",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "BoardId",
                table: "TodoItems");
        }
    }
}
