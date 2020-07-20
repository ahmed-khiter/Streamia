using Microsoft.EntityFrameworkCore.Migrations;

namespace Streamia.Migrations
{
    public partial class updateMovieModelRemoveRedundantOptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChannelSid",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Extension",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "NativeFrame",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ProcessMovie",
                table: "Movies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChannelSid",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Extension",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "NativeFrame",
                table: "Movies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ProcessMovie",
                table: "Movies",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
