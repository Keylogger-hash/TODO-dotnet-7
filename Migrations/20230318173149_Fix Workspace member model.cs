using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TODO.Migrations
{
    /// <inheritdoc />
    public partial class FixWorkspacemembermodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkspacesMembers_AspNetUsers_UserId1",
                table: "WorkspacesMembers");

            migrationBuilder.DropIndex(
                name: "IX_WorkspacesMembers_UserId1",
                table: "WorkspacesMembers");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "WorkspacesMembers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "WorkspacesMembers",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_WorkspacesMembers_UserId",
                table: "WorkspacesMembers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkspacesMembers_AspNetUsers_UserId",
                table: "WorkspacesMembers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkspacesMembers_AspNetUsers_UserId",
                table: "WorkspacesMembers");

            migrationBuilder.DropIndex(
                name: "IX_WorkspacesMembers_UserId",
                table: "WorkspacesMembers");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "WorkspacesMembers",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "WorkspacesMembers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_WorkspacesMembers_UserId1",
                table: "WorkspacesMembers",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkspacesMembers_AspNetUsers_UserId1",
                table: "WorkspacesMembers",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
