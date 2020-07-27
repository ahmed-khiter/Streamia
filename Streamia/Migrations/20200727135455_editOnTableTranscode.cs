using Microsoft.EntityFrameworkCore.Migrations;

namespace Streamia.Migrations
{
    public partial class editOnTableTranscode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TranscodeState",
                table: "Transcodes");

            migrationBuilder.AddColumn<int>(
                name: "Hardware",
                table: "Transcodes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hardware",
                table: "Transcodes");

            migrationBuilder.AddColumn<int>(
                name: "TranscodeState",
                table: "Transcodes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
