using Microsoft.EntityFrameworkCore.Migrations;

namespace Streamia.Migrations
{
    public partial class updateEpisodeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "Episode",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Episode",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Overview",
                table: "Episode",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Rating",
                table: "Episode",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "ReleaseDate",
                table: "Episode",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "Rating",
                table: "Episode");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Episode");
        }
    }
}
