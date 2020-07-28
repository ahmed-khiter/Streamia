using Microsoft.EntityFrameworkCore.Migrations;

namespace Streamia.Migrations
{
    public partial class updateStreamModelnames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllowRecording",
                table: "Streams");

            migrationBuilder.DropColumn(
                name: "AllowRtmp",
                table: "Streams");

            migrationBuilder.DropColumn(
                name: "DirectSource",
                table: "Streams");

            migrationBuilder.DropColumn(
                name: "MinuteDelay",
                table: "Streams");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Streams");

            migrationBuilder.DropColumn(
                name: "StreamAll",
                table: "Streams");

            migrationBuilder.AddColumn<int>(
                name: "Delay",
                table: "Streams",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "EnableRecording",
                table: "Streams",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EnableRtmp",
                table: "Streams",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StreamDirectly",
                table: "Streams",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Delay",
                table: "Streams");

            migrationBuilder.DropColumn(
                name: "EnableRecording",
                table: "Streams");

            migrationBuilder.DropColumn(
                name: "EnableRtmp",
                table: "Streams");

            migrationBuilder.DropColumn(
                name: "StreamDirectly",
                table: "Streams");

            migrationBuilder.AddColumn<bool>(
                name: "AllowRecording",
                table: "Streams",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AllowRtmp",
                table: "Streams",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DirectSource",
                table: "Streams",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MinuteDelay",
                table: "Streams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Streams",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "StreamAll",
                table: "Streams",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
