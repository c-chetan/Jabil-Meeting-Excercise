﻿// <auto-generated />
using System;
using MeetingAppDataLayer.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MeetingAppDataLayer.Migrations
{
    [DbContext(typeof(MeetDBContext))]
    [Migration("20200129125358_RemoveFKFromColumnName")]
    partial class RemoveFKFromColumnName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MeetingAppDataLayer.Models.Attendee", b =>
                {
                    b.Property<int>("AttendeeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AttendeeName");

                    b.Property<bool>("IsMeetingOwner");

                    b.Property<int?>("MeetingAttendeeId");

                    b.Property<int?>("UserAttendeeId");

                    b.HasKey("AttendeeId");

                    b.HasIndex("MeetingAttendeeId");

                    b.HasIndex("UserAttendeeId");

                    b.ToTable("Attendees");
                });

            modelBuilder.Entity("MeetingAppDataLayer.Models.Meeting", b =>
                {
                    b.Property<int>("MeetingId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MeetingAgenda")
                        .IsRequired();

                    b.Property<DateTime>("MeetingDate");

                    b.Property<string>("MeetingSubject")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("MeetingId");

                    b.ToTable("Meetings");
                });

            modelBuilder.Entity("MeetingAppDataLayer.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("UserCode");

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.HasKey("UserId");

                    b.ToTable("AuthUser");
                });

            modelBuilder.Entity("MeetingAppDataLayer.Models.Attendee", b =>
                {
                    b.HasOne("MeetingAppDataLayer.Models.Meeting", "Meeting")
                        .WithMany("Attendees")
                        .HasForeignKey("MeetingAttendeeId");

                    b.HasOne("MeetingAppDataLayer.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserAttendeeId");
                });
#pragma warning restore 612, 618
        }
    }
}
