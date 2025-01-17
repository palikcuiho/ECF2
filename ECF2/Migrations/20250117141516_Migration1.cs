using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECF2.Migrations
{
    /// <inheritdoc />
    public partial class Migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "event_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_event_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "participant",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_participant", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "event",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    event_type_id = table.Column<int>(type: "int", nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false),
                    participant_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_event", x => x.id);
                    table.ForeignKey(
                        name: "fk_event_event_type_event_type_id",
                        column: x => x.event_type_id,
                        principalTable: "event_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_event_participant_participant_id",
                        column: x => x.participant_id,
                        principalTable: "participant",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "event_type",
                columns: new[] { "id", "type" },
                values: new object[,]
                {
                    { 1, "bar mitzvah" },
                    { 2, "funérailles" }
                });

            migrationBuilder.InsertData(
                table: "participant",
                columns: new[] { "id", "email", "first_name", "last_name", "phone" },
                values: new object[,]
                {
                    { 1, "childeric.dupont@mail.com", "Childéric", "Dupont", "0123456789" },
                    { 2, "merofledemartin@aliceadsl.fr", "Méroflède", "Martin", "0102030405" },
                    { 3, "brunehilde666@hotmail.com", "Brunehilde", "Martin", "0836656565" }
                });

            migrationBuilder.InsertData(
                table: "event",
                columns: new[] { "id", "address", "description", "end_date", "event_type_id", "participant_id", "start_date", "title" },
                values: new object[,]
                {
                    { 1, "123 rue de AAA, 59000 Lille", "Description", new DateTime(2025, 1, 25, 2, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Titre 2" },
                    { 2, "La Civette, Le Cateau-Cambrésis", "Description 2", new DateTime(2025, 2, 1, 3, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Titre 2" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_event_event_type_id",
                table: "event",
                column: "event_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_event_participant_id",
                table: "event",
                column: "participant_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "event");

            migrationBuilder.DropTable(
                name: "event_type");

            migrationBuilder.DropTable(
                name: "participant");
        }
    }
}
