using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECF2.Migrations
{
    /// <inheritdoc />
    public partial class Migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "event",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "description", "title" },
                values: new object[] { "Description 1", "Titre 1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "event",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "description", "title" },
                values: new object[] { "Description", "Titre 2" });
        }
    }
}
