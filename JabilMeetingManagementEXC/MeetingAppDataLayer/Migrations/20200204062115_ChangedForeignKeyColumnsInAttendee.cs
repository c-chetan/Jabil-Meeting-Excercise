using Microsoft.EntityFrameworkCore.Migrations;

namespace MeetingAppDataLayer.Migrations
{
    public partial class ChangedForeignKeyColumnsInAttendee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendees_Meetings_MeetingAttendeeId",
                table: "Attendees");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendees_AuthUser_UserAttendeeId",
                table: "Attendees");

            migrationBuilder.RenameColumn(
                name: "UserAttendeeId",
                table: "Attendees",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "MeetingAttendeeId",
                table: "Attendees",
                newName: "MeetingId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendees_UserAttendeeId",
                table: "Attendees",
                newName: "IX_Attendees_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendees_MeetingAttendeeId",
                table: "Attendees",
                newName: "IX_Attendees_MeetingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendees_Meetings_MeetingId",
                table: "Attendees",
                column: "MeetingId",
                principalTable: "Meetings",
                principalColumn: "MeetingId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendees_AuthUser_UserId",
                table: "Attendees",
                column: "UserId",
                principalTable: "AuthUser",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendees_Meetings_MeetingId",
                table: "Attendees");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendees_AuthUser_UserId",
                table: "Attendees");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Attendees",
                newName: "UserAttendeeId");

            migrationBuilder.RenameColumn(
                name: "MeetingId",
                table: "Attendees",
                newName: "MeetingAttendeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendees_UserId",
                table: "Attendees",
                newName: "IX_Attendees_UserAttendeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendees_MeetingId",
                table: "Attendees",
                newName: "IX_Attendees_MeetingAttendeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendees_Meetings_MeetingAttendeeId",
                table: "Attendees",
                column: "MeetingAttendeeId",
                principalTable: "Meetings",
                principalColumn: "MeetingId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendees_AuthUser_UserAttendeeId",
                table: "Attendees",
                column: "UserAttendeeId",
                principalTable: "AuthUser",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
