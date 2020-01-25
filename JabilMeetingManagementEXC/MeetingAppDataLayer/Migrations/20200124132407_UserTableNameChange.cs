using Microsoft.EntityFrameworkCore.Migrations;

namespace MeetingAppDataLayer.Migrations
{
    public partial class UserTableNameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "AuthUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthUser",
                table: "AuthUser",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthUser",
                table: "AuthUser");

            migrationBuilder.RenameTable(
                name: "AuthUser",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");
        }
    }
}
