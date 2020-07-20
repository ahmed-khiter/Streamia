using Microsoft.EntityFrameworkCore.Migrations;

namespace Streamia.Migrations
{
    public partial class updateMovieModelTMDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackdropUrl",
                table: "Movies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BackdropUrl",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
