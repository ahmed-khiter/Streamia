using Microsoft.EntityFrameworkCore.Migrations;

namespace Streamia.Migrations
{
    public partial class updateEpisodeNotMappeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Director",
                table: "Episode");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Episode");

            migrationBuilder.DropColumn(
                name: "Overview",
                table: "Episode");

            migrationBuilder.DropColumn(
                name: "PosterUrl",
                table: "Episode");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Episode");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Episode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "Episode",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Episode",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Overview",
                table: "Episode",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PosterUrl",
                table: "Episode",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Rating",
                table: "Episode",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "ReleaseDate",
                table: "Episode",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
