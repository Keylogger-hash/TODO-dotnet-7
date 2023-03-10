using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TODO.Migrations
{
    /// <inheritdoc />
    public partial class AddUserToTodoItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserTodoItemForeignKey",
                table: "TodoItems",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_UserTodoItemForeignKey",
                table: "TodoItems",
                column: "UserTodoItemForeignKey");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_AspNetUsers_UserTodoItemForeignKey",
                table: "TodoItems",
                column: "UserTodoItemForeignKey",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_AspNetUsers_UserTodoItemForeignKey",
                table: "TodoItems");

            migrationBuilder.DropIndex(
                name: "IX_TodoItems_UserTodoItemForeignKey",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "UserTodoItemForeignKey",
                table: "TodoItems");
        }
    }
}
