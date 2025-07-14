using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartTray.Infra.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameFKTraySettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tray_tray_settings_tray_id",
                table: "tray");

            migrationBuilder.RenameColumn(
                name: "tray_id",
                table: "tray",
                newName: "tray_settings_id");

            migrationBuilder.RenameIndex(
                name: "IX_tray_tray_id",
                table: "tray",
                newName: "IX_tray_tray_settings_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tray_tray_settings_tray_settings_id",
                table: "tray",
                column: "tray_settings_id",
                principalTable: "tray_settings",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tray_tray_settings_tray_settings_id",
                table: "tray");

            migrationBuilder.RenameColumn(
                name: "tray_settings_id",
                table: "tray",
                newName: "tray_id");

            migrationBuilder.RenameIndex(
                name: "IX_tray_tray_settings_id",
                table: "tray",
                newName: "IX_tray_tray_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tray_tray_settings_tray_id",
                table: "tray",
                column: "tray_id",
                principalTable: "tray_settings",
                principalColumn: "Id");
        }
    }
}
