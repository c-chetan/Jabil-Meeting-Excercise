using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeetingAppDataLayer.Migrations
{
    public partial class CreatedAttendeeMeetingTableCorreced : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meetings",
                columns: table => new
                {
                    MeetingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MeetingSubject = table.Column<string>(maxLength: 50, nullable: false),
                    MeetingAgenda = table.Column<string>(nullable: false),
                    MeetingDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.MeetingId);
                });

            migrationBuilder.CreateTable(
                name: "Attendees",
                columns: table => new
                {
                    AttendeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttendeeName = table.Column<string>(nullable: true),
                    IsMeetingOwner = table.Column<bool>(nullable: false),
                    FK_UserAttendeeId = table.Column<int>(nullable: true),
                    FK_MeetingAttendeeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendees", x => x.AttendeeId);
                    table.ForeignKey(
                        name: "FK_Attendees_Meetings_FK_MeetingAttendeeId",
                        column: x => x.FK_MeetingAttendeeId,
                        principalTable: "Meetings",
                        principalColumn: "MeetingId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attendees_AuthUser_FK_UserAttendeeId",
                        column: x => x.FK_UserAttendeeId,
                        principalTable: "AuthUser",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendees_FK_MeetingAttendeeId",
                table: "Attendees",
                column: "FK_MeetingAttendeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendees_FK_UserAttendeeId",
                table: "Attendees",
                column: "FK_UserAttendeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendees");

            migrationBuilder.DropTable(
                name: "Meetings");
        }
    }
}
