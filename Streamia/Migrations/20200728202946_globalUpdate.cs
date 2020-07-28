using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Streamia.Migrations
{
    public partial class globalUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DirectSource",
                table: "Movies");

            migrationBuilder.AddColumn<DateTime>(
                name: "Uptime",
                table: "Streams",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "StreamDirectly",
                table: "Serieses",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Uptime",
                table: "Serieses",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "StreamDirectly",
                table: "Movies",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Uptime",
                table: "Movies",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Uptime",
                table: "Streams");

            migrationBuilder.DropColumn(
                name: "StreamDirectly",
                table: "Serieses");

            migrationBuilder.DropColumn(
                name: "Uptime",
                table: "Serieses");

            migrationBuilder.DropColumn(
                name: "StreamDirectly",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Uptime",
                table: "Movies");

            migrationBuilder.AddColumn<bool>(
                name: "DirectSource",
                table: "Movies",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
