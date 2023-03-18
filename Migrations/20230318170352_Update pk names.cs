using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TODO.Migrations
{
    /// <inheritdoc />
    public partial class Updatepknames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TodoItems",
                newName: "ItemId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Board",
                newName: "BoardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "TodoItems",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BoardId",
                table: "Board",
                newName: "Id");
        }
    }
}
