using Microsoft.EntityFrameworkCore.Migrations;

namespace Streamia.Migrations
{
    public partial class m2m : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BouquetSources");

            migrationBuilder.DropTable(
                name: "SourceServers");

            migrationBuilder.CreateTable(
                name: "StreamServer",
                columns: table => new
                {
                    StreamId = table.Column<int>(nullable: false),
                    ServerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StreamServer", x => new { x.StreamId, x.ServerId });
                    table.ForeignKey(
                        name: "FK_StreamServer_Servers_ServerId",
                        column: x => x.ServerId,
                        principalTable: "Servers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StreamServer_Streams_StreamId",
                        column: x => x.StreamId,
                        principalTable: "Streams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StreamServer_ServerId",
                table: "StreamServer",
                column: "ServerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StreamServer");

            migrationBuilder.CreateTable(
                name: "BouquetSources",
                columns: table => new
                {
                    SourceId = table.Column<int>(type: "int", nullable: false),
                    BouquetId = table.Column<int>(type: "int", nullable: false),
                    SourceType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BouquetSources", x => new { x.SourceId, x.BouquetId });
                    table.ForeignKey(
                        name: "FK_BouquetSources_Bouquets_BouquetId",
                        column: x => x.BouquetId,
                        principalTable: "Bouquets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SourceServers",
                columns: table => new
                {
                    SourceId = table.Column<int>(type: "int", nullable: false),
                    ServerId = table.Column<int>(type: "int", nullable: false),
                    SourceType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SourceServers", x => new { x.SourceId, x.ServerId });
                    table.ForeignKey(
                        name: "FK_SourceServers_Servers_ServerId",
                        column: x => x.ServerId,
                        principalTable: "Servers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BouquetSources_BouquetId",
                table: "BouquetSources",
                column: "BouquetId");

            migrationBuilder.CreateIndex(
                name: "IX_SourceServers_ServerId",
                table: "SourceServers",
                column: "ServerId");
        }
    }
}
