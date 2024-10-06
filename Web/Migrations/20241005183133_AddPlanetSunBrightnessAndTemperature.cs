using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class AddPlanetSunBrightnessAndTemperature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "RelativeSunBrightness",
                table: "Planets",
                type: "decimal(20,4)",
                precision: 20,
                scale: 4,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "SunTemperatureInKelvin",
                table: "Planets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RelativeSunBrightness",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "SunTemperatureInKelvin",
                table: "Planets");
        }
    }
}
