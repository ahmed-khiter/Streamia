using Microsoft.EntityFrameworkCore.Migrations;

namespace Streamia.Migrations
{
    public partial class SeriesModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BouquetSeries",
                columns: table => new
                {
                    BouquetId = table.Column<int>(nullable: false),
                    SeriesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BouquetSeries", x => new { x.BouquetId, x.SeriesId });
                    table.ForeignKey(
                        name: "FK_BouquetSeries_Bouquets_BouquetId",
                        column: x => x.BouquetId,
                        principalTable: "Bouquets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BouquetSeries_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Episode",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId1 = table.Column<int>(nullable: true),
                    State = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    PosterUrl = table.Column<string>(nullable: true),
                    Overview = table.Column<string>(nullable: true),
                    Cast = table.Column<string>(nullable: true),
                    Director = table.Column<string>(nullable: true),
                    Gener = table.Column<string>(nullable: true),
                    ReleaseDate = table.Column<string>(nullable: true),
                    Runtime = table.Column<int>(nullable: false),
                    Rating = table.Column<float>(nullable: false),
                    SeriesId = table.Column<int>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    Season = table.Column<int>(nullable: false),
                    Source = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Episode_Categories_CategoryId1",
                        column: x => x.CategoryId1,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Episode_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeriesServer",
                columns: table => new
                {
                    SeriesId = table.Column<int>(nullable: false),
                    ServerId = table.Column<int>(nullable: false),
                    Pid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesServer", x => new { x.SeriesId, x.ServerId });
                    table.ForeignKey(
                        name: "FK_SeriesServer_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SeriesServer_Servers_ServerId",
                        column: x => x.ServerId,
                        principalTable: "Servers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BouquetSeries_SeriesId",
                table: "BouquetSeries",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Episode_CategoryId1",
                table: "Episode",
                column: "CategoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_Episode_SeriesId",
                table: "Episode",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesServer_ServerId",
                table: "SeriesServer",
                column: "ServerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BouquetSeries");

            migrationBuilder.DropTable(
                name: "Episode");

            migrationBuilder.DropTable(
                name: "SeriesServer");
        }
    }
}
