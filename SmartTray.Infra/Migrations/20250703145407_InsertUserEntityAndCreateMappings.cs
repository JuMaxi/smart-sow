using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SmartTray.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InsertUserEntityAndCreateMappings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TraySensorReadings_Trays_TrayId",
                table: "TraySensorReadings");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TraySensorReadings",
                table: "TraySensorReadings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trays",
                table: "Trays");

            migrationBuilder.DropColumn(
                name: "UvReading",
                table: "TraySensorReadings");

            migrationBuilder.RenameTable(
                name: "TraySensorReadings",
                newName: "tray_sensor_readings");

            migrationBuilder.RenameTable(
                name: "Trays",
                newName: "tray");

            migrationBuilder.RenameColumn(
                name: "Humidity",
                table: "tray_sensor_readings",
                newName: "humidity");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "tray_sensor_readings",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "WaterAdded",
                table: "tray_sensor_readings",
                newName: "water_added");

            migrationBuilder.RenameColumn(
                name: "UvLedsOn",
                table: "tray_sensor_readings",
                newName: "uv_leds_on");

            migrationBuilder.RenameColumn(
                name: "Temperature",
                table: "tray_sensor_readings",
                newName: "temperature_celsius");

            migrationBuilder.RenameIndex(
                name: "IX_TraySensorReadings_TrayId",
                table: "tray_sensor_readings",
                newName: "IX_tray_sensor_readings_TrayId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "tray",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "SowingDate",
                table: "tray",
                newName: "sowing_date");

            migrationBuilder.RenameColumn(
                name: "CropType",
                table: "tray",
                newName: "crop_type");

            migrationBuilder.AlterColumn<int>(
                name: "humidity",
                table: "tray_sensor_readings",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<int>(
                name: "temperature_celsius",
                table: "tray_sensor_readings",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AddColumn<bool>(
                name: "heating_mat_on",
                table: "tray_sensor_readings",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "uv",
                table: "tray_sensor_readings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "tray",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "crop_type",
                table: "tray",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "tray",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "tray",
                type: "integer",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "tray_id",
                table: "tray",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tray_sensor_readings",
                table: "tray_sensor_readings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tray",
                table: "tray",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "tray_settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    register_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    temperature_celsius = table.Column<int>(type: "integer", nullable: false),
                    humidity = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    daily_solar_hours = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tray_settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    password_hash = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    salt = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    post_code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tray_tray_id",
                table: "tray",
                column: "tray_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tray_UserId",
                table: "tray",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_tray_tray_settings_tray_id",
                table: "tray",
                column: "tray_id",
                principalTable: "tray_settings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tray_users_UserId",
                table: "tray",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tray_sensor_readings_tray_TrayId",
                table: "tray_sensor_readings",
                column: "TrayId",
                principalTable: "tray",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tray_tray_settings_tray_id",
                table: "tray");

            migrationBuilder.DropForeignKey(
                name: "FK_tray_users_UserId",
                table: "tray");

            migrationBuilder.DropForeignKey(
                name: "FK_tray_sensor_readings_tray_TrayId",
                table: "tray_sensor_readings");

            migrationBuilder.DropTable(
                name: "tray_settings");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tray_sensor_readings",
                table: "tray_sensor_readings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tray",
                table: "tray");

            migrationBuilder.DropIndex(
                name: "IX_tray_tray_id",
                table: "tray");

            migrationBuilder.DropIndex(
                name: "IX_tray_UserId",
                table: "tray");

            migrationBuilder.DropColumn(
                name: "heating_mat_on",
                table: "tray_sensor_readings");

            migrationBuilder.DropColumn(
                name: "uv",
                table: "tray_sensor_readings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "tray");

            migrationBuilder.DropColumn(
                name: "status",
                table: "tray");

            migrationBuilder.DropColumn(
                name: "tray_id",
                table: "tray");

            migrationBuilder.RenameTable(
                name: "tray_sensor_readings",
                newName: "TraySensorReadings");

            migrationBuilder.RenameTable(
                name: "tray",
                newName: "Trays");

            migrationBuilder.RenameColumn(
                name: "humidity",
                table: "TraySensorReadings",
                newName: "Humidity");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "TraySensorReadings",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "water_added",
                table: "TraySensorReadings",
                newName: "WaterAdded");

            migrationBuilder.RenameColumn(
                name: "uv_leds_on",
                table: "TraySensorReadings",
                newName: "UvLedsOn");

            migrationBuilder.RenameColumn(
                name: "temperature_celsius",
                table: "TraySensorReadings",
                newName: "Temperature");

            migrationBuilder.RenameIndex(
                name: "IX_tray_sensor_readings_TrayId",
                table: "TraySensorReadings",
                newName: "IX_TraySensorReadings_TrayId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Trays",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "sowing_date",
                table: "Trays",
                newName: "SowingDate");

            migrationBuilder.RenameColumn(
                name: "crop_type",
                table: "Trays",
                newName: "CropType");

            migrationBuilder.AlterColumn<double>(
                name: "Humidity",
                table: "TraySensorReadings",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<double>(
                name: "Temperature",
                table: "TraySensorReadings",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<double>(
                name: "UvReading",
                table: "TraySensorReadings",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Trays",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "CropType",
                table: "Trays",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TraySensorReadings",
                table: "TraySensorReadings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trays",
                table: "Trays",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DailySolarHours = table.Column<double>(type: "double precision", nullable: false),
                    Humidity = table.Column<double>(type: "double precision", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TemperatureCelsius = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_TraySensorReadings_Trays_TrayId",
                table: "TraySensorReadings",
                column: "TrayId",
                principalTable: "Trays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
