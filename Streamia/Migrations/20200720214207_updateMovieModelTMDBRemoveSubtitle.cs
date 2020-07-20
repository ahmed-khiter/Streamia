using Microsoft.EntityFrameworkCore.Migrations;

namespace Streamia.Migrations
{
    public partial class updateMovieModelTMDBRemoveSubtitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Series_Categories_CategoryId",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "RemoveExistingSubtitle",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "SubtitleLocation",
                table: "Movies");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Series",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cast",
                table: "Series",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "Series",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gener",
                table: "Series",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Overview",
                table: "Series",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PosterUrl",
                table: "Series",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Rating",
                table: "Series",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "ReleaseDate",
                table: "Series",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Runtime",
                table: "Series",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Series",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StreamKey",
                table: "Series",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Series_Categories_CategoryId",
                table: "Series",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Series_Categories_CategoryId",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "Cast",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "Director",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "Gener",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "Overview",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "PosterUrl",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "Runtime",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "StreamKey",
                table: "Series");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Series",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<bool>(
                name: "RemoveExistingSubtitle",
                table: "Movies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SubtitleLocation",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Series_Categories_CategoryId",
                table: "Series",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
