using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartTray.Infra.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableTraySensorReadingAndTableTrays : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CropType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SowingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TraySensorReadings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrayId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Temperature = table.Column<double>(type: "float", nullable: false),
                    Humidity = table.Column<double>(type: "float", nullable: false),
                    UvReading = table.Column<double>(type: "float", nullable: false),
                    WaterAdded = table.Column<bool>(type: "bit", nullable: false),
                    UvLedsOn = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TraySensorReadings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TraySensorReadings_Trays_TrayId",
                        column: x => x.TrayId,
                        principalTable: "Trays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TraySensorReadings_TrayId",
                table: "TraySensorReadings",
                column: "TrayId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TraySensorReadings");

            migrationBuilder.DropTable(
                name: "Trays");
        }
    }
}
