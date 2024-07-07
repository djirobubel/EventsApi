using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventsApi.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Events",
                newName: "TimeOfCreation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimeOfCreation",
                table: "Events",
                newName: "Time");
        }
    }
}
