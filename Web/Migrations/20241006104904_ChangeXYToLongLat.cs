using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class ChangeXYToLongLat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Y",
                table: "VisibleStars",
                newName: "Longitude");

            migrationBuilder.RenameColumn(
                name: "X",
                table: "VisibleStars",
                newName: "Latitude");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "VisibleStars",
                newName: "Y");

            migrationBuilder.RenameColumn(
                name: "Latitude",
                table: "VisibleStars",
                newName: "X");
        }
    }
}
