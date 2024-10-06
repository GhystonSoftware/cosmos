using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class AddRemainingPlanetInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RelativeBrightnessToSun",
                table: "Planets",
                newName: "YearInEarthDays");

            migrationBuilder.AddColumn<string>(
                name: "PlanetProperty",
                table: "Planets",
                type: "VARCHAR(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "RelativeTemperatureToEarth",
                table: "Planets",
                type: "decimal(20,4)",
                precision: 20,
                scale: 4,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "SunColor",
                table: "Planets",
                type: "VARCHAR(100)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlanetProperty",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "RelativeTemperatureToEarth",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "SunColor",
                table: "Planets");

            migrationBuilder.RenameColumn(
                name: "YearInEarthDays",
                table: "Planets",
                newName: "RelativeBrightnessToSun");
        }
    }
}
