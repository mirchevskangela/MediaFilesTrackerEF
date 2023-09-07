using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbServiceEFCoreV4.DbMigrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Action = table.Column<string>(nullable: true, defaultValue: "Created")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CameraConfigurations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CameraName = table.Column<string>(nullable: true),
                    FolderPath = table.Column<string>(nullable: true),
                    VideoExtension = table.Column<string>(nullable: true),
                    PhotoExtension = table.Column<string>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CameraConfigurations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhotoExtensions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Extension = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoExtensions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VideoExtensions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Extension = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoExtensions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConfigurationModificationDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CameraName = table.Column<string>(nullable: true),
                    FolderPath = table.Column<string>(nullable: true),
                    VideoExtension = table.Column<string>(nullable: true),
                    PhotoExtension = table.Column<string>(nullable: true),
                    ActionsID = table.Column<int>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigurationModificationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfigurationModificationDetails_Actions_ActionsID",
                        column: x => x.ActionsID,
                        principalTable: "Actions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonitoringDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CameraConfigurationID = table.Column<int>(nullable: false),
                    ActionsID = table.Column<int>(nullable: false),
                    FolderPath = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    StartTimestamp = table.Column<DateTime>(nullable: false),
                    EndTimestamp = table.Column<DateTime>(nullable: false),
                    IsVideo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonitoringDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonitoringDetails_Actions_ActionsID",
                        column: x => x.ActionsID,
                        principalTable: "Actions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonitoringDetails_CameraConfigurations_CameraConfigurationID",
                        column: x => x.CameraConfigurationID,
                        principalTable: "CameraConfigurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actions",
                columns: new[] { "Id", "Action" },
                values: new object[,]
                {
                    { 1, "Created" },
                    { 2, "Modified" },
                    { 3, "Deleted" }
                });

            migrationBuilder.InsertData(
                table: "PhotoExtensions",
                columns: new[] { "Id", "Extension" },
                values: new object[,]
                {
                    { 20, "k25" },
                    { 19, "nrw" },
                    { 18, "rw2" },
                    { 17, "cr" },
                    { 15, "raw" },
                    { 14, "psd" },
                    { 13, "tif" },
                    { 12, "tiff" },
                    { 11, "webp" },
                    { 16, "arw" },
                    { 9, "svgz" },
                    { 8, "svg" },
                    { 7, "png" },
                    { 6, "jfif" },
                    { 5, "jif" },
                    { 4, "jpe" },
                    { 3, "jfi" },
                    { 2, "jpeg" },
                    { 1, "jpg" },
                    { 10, "pdf" }
                });

            migrationBuilder.InsertData(
                table: "VideoExtensions",
                columns: new[] { "Id", "Extension" },
                values: new object[,]
                {
                    { 12, "AVC" },
                    { 11, "AVCHD" },
                    { 10, "WMV" },
                    { 9, "AVI" },
                    { 8, "OGG" },
                    { 7, "WEBM" },
                    { 2, "MP2" },
                    { 5, "MPE" },
                    { 4, "MPEG" },
                    { 3, "MP3" },
                    { 1, "MPG" },
                    { 13, "MP4" },
                    { 6, "MPV" },
                    { 14, "M4P" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConfigurationModificationDetails_ActionsID",
                table: "ConfigurationModificationDetails",
                column: "ActionsID");

            migrationBuilder.CreateIndex(
                name: "IX_MonitoringDetails_ActionsID",
                table: "MonitoringDetails",
                column: "ActionsID");

            migrationBuilder.CreateIndex(
                name: "IX_MonitoringDetails_CameraConfigurationID",
                table: "MonitoringDetails",
                column: "CameraConfigurationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfigurationModificationDetails");

            migrationBuilder.DropTable(
                name: "MonitoringDetails");

            migrationBuilder.DropTable(
                name: "PhotoExtensions");

            migrationBuilder.DropTable(
                name: "VideoExtensions");

            migrationBuilder.DropTable(
                name: "Actions");

            migrationBuilder.DropTable(
                name: "CameraConfigurations");
        }
    }
}
