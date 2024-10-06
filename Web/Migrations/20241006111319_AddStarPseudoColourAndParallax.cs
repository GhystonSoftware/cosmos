using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class AddStarPseudoColourAndParallax : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DistanceFromEarthInParsecs",
                table: "Stars",
                newName: "PseudoColour");

            migrationBuilder.AddColumn<decimal>(
                name: "Parallax",
                table: "Stars",
                type: "decimal(20,4)",
                precision: 20,
                scale: 4,
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Parallax",
                table: "Stars");

            migrationBuilder.RenameColumn(
                name: "PseudoColour",
                table: "Stars",
                newName: "DistanceFromEarthInParsecs");
        }
    }
}
