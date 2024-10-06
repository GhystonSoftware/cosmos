using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class IncreasePrecision : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "VisibleStars",
                type: "decimal(15,10)",
                precision: 15,
                scale: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)",
                oldPrecision: 5,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "VisibleStars",
                type: "decimal(15,10)",
                precision: 15,
                scale: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)",
                oldPrecision: 5,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "Brightness",
                table: "VisibleStars",
                type: "decimal(13,10)",
                precision: 13,
                scale: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,3)",
                oldPrecision: 3,
                oldScale: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "VisibleStars",
                type: "decimal(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,10)",
                oldPrecision: 15,
                oldScale: 10);

            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "VisibleStars",
                type: "decimal(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,10)",
                oldPrecision: 15,
                oldScale: 10);

            migrationBuilder.AlterColumn<decimal>(
                name: "Brightness",
                table: "VisibleStars",
                type: "decimal(3,3)",
                precision: 3,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(13,10)",
                oldPrecision: 13,
                oldScale: 10);
        }
    }
}
