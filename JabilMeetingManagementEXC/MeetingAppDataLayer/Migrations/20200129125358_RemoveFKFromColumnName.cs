using Microsoft.EntityFrameworkCore.Migrations;

namespace MeetingAppDataLayer.Migrations
{
    public partial class RemoveFKFromColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendees_Meetings_FK_MeetingAttendeeId",
                table: "Attendees");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendees_AuthUser_FK_UserAttendeeId",
                table: "Attendees");

            migrationBuilder.RenameColumn(
                name: "FK_UserAttendeeId",
                table: "Attendees",
                newName: "UserAttendeeId");

            migrationBuilder.RenameColumn(
                name: "FK_MeetingAttendeeId",
                table: "Attendees",
                newName: "MeetingAttendeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendees_FK_UserAttendeeId",
                table: "Attendees",
                newName: "IX_Attendees_UserAttendeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendees_FK_MeetingAttendeeId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                newName: "FK_UserAttendeeId");

            migrationBuilder.RenameColumn(
                name: "MeetingAttendeeId",
                table: "Attendees",
                newName: "FK_MeetingAttendeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendees_UserAttendeeId",
                table: "Attendees",
                newName: "IX_Attendees_FK_UserAttendeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendees_MeetingAttendeeId",
                table: "Attendees",
                newName: "IX_Attendees_FK_MeetingAttendeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendees_Meetings_FK_MeetingAttendeeId",
                table: "Attendees",
                column: "FK_MeetingAttendeeId",
                principalTable: "Meetings",
                principalColumn: "MeetingId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendees_AuthUser_FK_UserAttendeeId",
                table: "Attendees",
                column: "FK_UserAttendeeId",
                principalTable: "AuthUser",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
