using Microsoft.EntityFrameworkCore.Migrations;

namespace MeetingAppDataLayer.Migrations
{
    public partial class MeetingColumnChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MeetingSubject",
                table: "Meetings",
                newName: "Subject");

            migrationBuilder.RenameColumn(
                name: "MeetingDate",
                table: "Meetings",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "MeetingAgenda",
                table: "Meetings",
                newName: "Agenda");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Subject",
                table: "Meetings",
                newName: "MeetingSubject");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Meetings",
                newName: "MeetingDate");

            migrationBuilder.RenameColumn(
                name: "Agenda",
                table: "Meetings",
                newName: "MeetingAgenda");
        }
    }
}
