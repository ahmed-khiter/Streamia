using Microsoft.EntityFrameworkCore.Migrations;

namespace Streamia.Migrations
{
    public partial class updateBouquetMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Categories_CategoryId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_CategoryId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Movies");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId1",
                table: "Movies",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BouquetMovie",
                columns: table => new
                {
                    BouquetId = table.Column<int>(nullable: false),
                    MovieId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BouquetMovie", x => new { x.BouquetId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_BouquetMovie_Bouquets_BouquetId",
                        column: x => x.BouquetId,
                        principalTable: "Bouquets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BouquetMovie_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CategoryId1",
                table: "Movies",
                column: "CategoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_BouquetMovie_MovieId",
                table: "BouquetMovie",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Categories_CategoryId1",
                table: "Movies",
                column: "CategoryId1",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Categories_CategoryId1",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "BouquetMovie");

            migrationBuilder.DropIndex(
                name: "IX_Movies_CategoryId1",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "Movies");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CategoryId",
                table: "Movies",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Categories_CategoryId",
                table: "Movies",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
