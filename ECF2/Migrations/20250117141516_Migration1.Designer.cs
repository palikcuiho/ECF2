﻿// <auto-generated />
using System;
using ECF2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ECF2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250117141516_Migration1")]
    partial class Migration1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ECF2.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("address");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("description");

                    b.Property<DateTime>("EndDate")
                        .HasPrecision(0)
                        .HasColumnType("datetime2(0)")
                        .HasColumnName("end_date");

                    b.Property<int>("EventTypeId")
                        .HasColumnType("int")
                        .HasColumnName("event_type_id");

                    b.Property<int?>("ParticipantId")
                        .HasColumnType("int")
                        .HasColumnName("participant_id");

                    b.Property<DateTime>("StartDate")
                        .HasPrecision(0)
                        .HasColumnType("datetime2(0)")
                        .HasColumnName("start_date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_event");

                    b.HasIndex("EventTypeId")
                        .HasDatabaseName("ix_event_event_type_id");

                    b.HasIndex("ParticipantId")
                        .HasDatabaseName("ix_event_participant_id");

                    b.ToTable("event", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "123 rue de AAA, 59000 Lille",
                            Description = "Description",
                            EndDate = new DateTime(2025, 1, 25, 2, 0, 0, 0, DateTimeKind.Unspecified),
                            EventTypeId = 2,
                            StartDate = new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Titre 2"
                        },
                        new
                        {
                            Id = 2,
                            Address = "La Civette, Le Cateau-Cambrésis",
                            Description = "Description 2",
                            EndDate = new DateTime(2025, 2, 1, 3, 0, 0, 0, DateTimeKind.Unspecified),
                            EventTypeId = 1,
                            StartDate = new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Titre 2"
                        });
                });

            modelBuilder.Entity("ECF2.Models.EventType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("type");

                    b.HasKey("Id")
                        .HasName("pk_event_type");

                    b.ToTable("event_type", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "bar mitzvah"
                        },
                        new
                        {
                            Id = 2,
                            Type = "funérailles"
                        });
                });

            modelBuilder.Entity("ECF2.Models.Participant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("last_name");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("phone");

                    b.HasKey("Id")
                        .HasName("pk_participant");

                    b.ToTable("participant", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "childeric.dupont@mail.com",
                            FirstName = "Childéric",
                            LastName = "Dupont",
                            Phone = "0123456789"
                        },
                        new
                        {
                            Id = 2,
                            Email = "merofledemartin@aliceadsl.fr",
                            FirstName = "Méroflède",
                            LastName = "Martin",
                            Phone = "0102030405"
                        },
                        new
                        {
                            Id = 3,
                            Email = "brunehilde666@hotmail.com",
                            FirstName = "Brunehilde",
                            LastName = "Martin",
                            Phone = "0836656565"
                        });
                });

            modelBuilder.Entity("ECF2.Models.Event", b =>
                {
                    b.HasOne("ECF2.Models.EventType", "EventType")
                        .WithMany()
                        .HasForeignKey("EventTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_event_event_type_event_type_id");

                    b.HasOne("ECF2.Models.Participant", null)
                        .WithMany("Events")
                        .HasForeignKey("ParticipantId")
                        .HasConstraintName("fk_event_participant_participant_id");

                    b.Navigation("EventType");
                });

            modelBuilder.Entity("ECF2.Models.Participant", b =>
                {
                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
