using Microsoft.EntityFrameworkCore.Migrations;

namespace Streamia.Migrations
{
    public partial class SeriesModelOverrideRuntime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BouquetSeries_Series_SeriesId",
                table: "BouquetSeries");

            migrationBuilder.DropForeignKey(
                name: "FK_Episode_Series_SeriesId",
                table: "Episode");

            migrationBuilder.DropForeignKey(
                name: "FK_Series_Categories_CategoryId",
                table: "Series");

            migrationBuilder.DropForeignKey(
                name: "FK_SeriesServer_Series_SeriesId",
                table: "SeriesServer");

            migrationBuilder.DropForeignKey(
                name: "FK_SeriesServer_Servers_ServerId",
                table: "SeriesServer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SeriesServer",
                table: "SeriesServer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Series",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "Runtime",
                table: "Series");

            migrationBuilder.RenameTable(
                name: "SeriesServer",
                newName: "SeriesServers");

            migrationBuilder.RenameTable(
                name: "Series",
                newName: "Serieses");

            migrationBuilder.RenameIndex(
                name: "IX_SeriesServer_ServerId",
                table: "SeriesServers",
                newName: "IX_SeriesServers_ServerId");

            migrationBuilder.RenameIndex(
                name: "IX_Series_CategoryId",
                table: "Serieses",
                newName: "IX_Serieses_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SeriesServers",
                table: "SeriesServers",
                columns: new[] { "SeriesId", "ServerId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Serieses",
                table: "Serieses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BouquetSeries_Serieses_SeriesId",
                table: "BouquetSeries",
                column: "SeriesId",
                principalTable: "Serieses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Episode_Serieses_SeriesId",
                table: "Episode",
                column: "SeriesId",
                principalTable: "Serieses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Serieses_Categories_CategoryId",
                table: "Serieses",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeriesServers_Serieses_SeriesId",
                table: "SeriesServers",
                column: "SeriesId",
                principalTable: "Serieses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SeriesServers_Servers_ServerId",
                table: "SeriesServers",
                column: "ServerId",
                principalTable: "Servers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BouquetSeries_Serieses_SeriesId",
                table: "BouquetSeries");

            migrationBuilder.DropForeignKey(
                name: "FK_Episode_Serieses_SeriesId",
                table: "Episode");

            migrationBuilder.DropForeignKey(
                name: "FK_Serieses_Categories_CategoryId",
                table: "Serieses");

            migrationBuilder.DropForeignKey(
                name: "FK_SeriesServers_Serieses_SeriesId",
                table: "SeriesServers");

            migrationBuilder.DropForeignKey(
                name: "FK_SeriesServers_Servers_ServerId",
                table: "SeriesServers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SeriesServers",
                table: "SeriesServers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Serieses",
                table: "Serieses");

            migrationBuilder.RenameTable(
                name: "SeriesServers",
                newName: "SeriesServer");

            migrationBuilder.RenameTable(
                name: "Serieses",
                newName: "Series");

            migrationBuilder.RenameIndex(
                name: "IX_SeriesServers_ServerId",
                table: "SeriesServer",
                newName: "IX_SeriesServer_ServerId");

            migrationBuilder.RenameIndex(
                name: "IX_Serieses_CategoryId",
                table: "Series",
                newName: "IX_Series_CategoryId");

            migrationBuilder.AddColumn<int>(
                name: "Runtime",
                table: "Series",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SeriesServer",
                table: "SeriesServer",
                columns: new[] { "SeriesId", "ServerId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Series",
                table: "Series",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BouquetSeries_Series_SeriesId",
                table: "BouquetSeries",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Episode_Series_SeriesId",
                table: "Episode",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Series_Categories_CategoryId",
                table: "Series",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeriesServer_Series_SeriesId",
                table: "SeriesServer",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SeriesServer_Servers_ServerId",
                table: "SeriesServer",
                column: "ServerId",
                principalTable: "Servers",
                principalColumn: "Id");
        }
    }
}
