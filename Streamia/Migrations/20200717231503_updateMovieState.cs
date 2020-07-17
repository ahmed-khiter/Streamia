using Microsoft.EntityFrameworkCore.Migrations;

namespace Streamia.Migrations
{
    public partial class updateMovieState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BouquetMovie_Bouquets_BouquetId",
                table: "BouquetMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_BouquetMovie_Movies_MovieId",
                table: "BouquetMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BouquetMovie",
                table: "BouquetMovie");

            migrationBuilder.RenameTable(
                name: "BouquetMovie",
                newName: "BouquetMovies");

            migrationBuilder.RenameIndex(
                name: "IX_BouquetMovie_MovieId",
                table: "BouquetMovies",
                newName: "IX_BouquetMovies_MovieId");

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Movies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BouquetMovies",
                table: "BouquetMovies",
                columns: new[] { "BouquetId", "MovieId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BouquetMovies_Bouquets_BouquetId",
                table: "BouquetMovies",
                column: "BouquetId",
                principalTable: "Bouquets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BouquetMovies_Movies_MovieId",
                table: "BouquetMovies",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BouquetMovies_Bouquets_BouquetId",
                table: "BouquetMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_BouquetMovies_Movies_MovieId",
                table: "BouquetMovies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BouquetMovies",
                table: "BouquetMovies");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Movies");

            migrationBuilder.RenameTable(
                name: "BouquetMovies",
                newName: "BouquetMovie");

            migrationBuilder.RenameIndex(
                name: "IX_BouquetMovies_MovieId",
                table: "BouquetMovie",
                newName: "IX_BouquetMovie_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BouquetMovie",
                table: "BouquetMovie",
                columns: new[] { "BouquetId", "MovieId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BouquetMovie_Bouquets_BouquetId",
                table: "BouquetMovie",
                column: "BouquetId",
                principalTable: "Bouquets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BouquetMovie_Movies_MovieId",
                table: "BouquetMovie",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id");
        }
    }
}
