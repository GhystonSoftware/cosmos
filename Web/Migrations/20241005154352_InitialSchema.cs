using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class InitialSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Planets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    RightAscensionInDegrees = table.Column<decimal>(type: "decimal(20,4)", precision: 20, scale: 4, nullable: false),
                    DeclinationInDegrees = table.Column<decimal>(type: "decimal(20,4)", precision: 20, scale: 4, nullable: false),
                    DistanceFromEarthInParsecs = table.Column<decimal>(type: "decimal(20,4)", precision: 20, scale: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    RightAscensionInDegrees = table.Column<decimal>(type: "decimal(20,4)", precision: 20, scale: 4, nullable: false),
                    DeclinationInDegrees = table.Column<decimal>(type: "decimal(20,4)", precision: 20, scale: 4, nullable: false),
                    DistanceFromEarthInParsecs = table.Column<decimal>(type: "decimal(20,4)", precision: 20, scale: 4, nullable: false),
                    Luminosity = table.Column<decimal>(type: "decimal(20,4)", precision: 20, scale: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StarMaps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StarMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StarMaps_Planets_PlanetId",
                        column: x => x.PlanetId,
                        principalTable: "Planets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Constellations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    StarMapId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Constellations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Constellations_StarMaps_StarMapId",
                        column: x => x.StarMapId,
                        principalTable: "StarMaps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VisibleStars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StarId = table.Column<int>(type: "int", nullable: false),
                    StarMapId = table.Column<int>(type: "int", nullable: false),
                    X = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    Y = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    Brightness = table.Column<decimal>(type: "decimal(3,3)", precision: 3, scale: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisibleStars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisibleStars_StarMaps_StarMapId",
                        column: x => x.StarMapId,
                        principalTable: "StarMaps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VisibleStars_Stars_StarId",
                        column: x => x.StarId,
                        principalTable: "Stars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConstellationLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConstellationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstellationLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConstellationLines_Constellations_ConstellationId",
                        column: x => x.ConstellationId,
                        principalTable: "Constellations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConstellationLines_ConstellationId",
                table: "ConstellationLines",
                column: "ConstellationId");

            migrationBuilder.CreateIndex(
                name: "IX_Constellations_StarMapId",
                table: "Constellations",
                column: "StarMapId");

            migrationBuilder.CreateIndex(
                name: "IX_StarMaps_PlanetId",
                table: "StarMaps",
                column: "PlanetId");

            migrationBuilder.CreateIndex(
                name: "IX_VisibleStars_StarId",
                table: "VisibleStars",
                column: "StarId");

            migrationBuilder.CreateIndex(
                name: "IX_VisibleStars_StarMapId",
                table: "VisibleStars",
                column: "StarMapId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConstellationLines");

            migrationBuilder.DropTable(
                name: "VisibleStars");

            migrationBuilder.DropTable(
                name: "Constellations");

            migrationBuilder.DropTable(
                name: "Stars");

            migrationBuilder.DropTable(
                name: "StarMaps");

            migrationBuilder.DropTable(
                name: "Planets");
        }
    }
}
