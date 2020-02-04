using Microsoft.EntityFrameworkCore.Migrations;

namespace MeetingAppDataLayer.Migrations
{
    public partial class AddedDisplayNameInUserAndRemovedAttendeeNameFromAttendee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttendeeName",
                table: "Attendees");

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "AuthUser",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "AuthUser");

            migrationBuilder.AddColumn<string>(
                name: "AttendeeName",
                table: "Attendees",
                nullable: true);
        }
    }
}
