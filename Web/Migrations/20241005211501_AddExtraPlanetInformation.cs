using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class AddExtraPlanetInformation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RelativeSunBrightness",
                table: "Planets",
                newName: "RelativeSizeToEarth");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfStarsInSystem",
                table: "Planets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "RelativeBrightnessToSun",
                table: "Planets",
                type: "decimal(20,4)",
                precision: 20,
                scale: 4,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "RelativeGravityToEarth",
                table: "Planets",
                type: "decimal(20,4)",
                precision: 20,
                scale: 4,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "RelativeMassToEarth",
                table: "Planets",
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
                name: "NumberOfStarsInSystem",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "RelativeBrightnessToSun",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "RelativeGravityToEarth",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "RelativeMassToEarth",
                table: "Planets");

            migrationBuilder.RenameColumn(
                name: "RelativeSizeToEarth",
                table: "Planets",
                newName: "RelativeSunBrightness");
        }
    }
}
