using Microsoft.EntityFrameworkCore.Migrations;

namespace Streamia.Migrations
{
    public partial class addOnDeleteAction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BouquetStreams_Bouquets_BouquetId",
                table: "BouquetStreams");

            migrationBuilder.DropForeignKey(
                name: "FK_BouquetStreams_Streams_StreamId",
                table: "BouquetStreams");

            migrationBuilder.DropForeignKey(
                name: "FK_StreamServers_Servers_ServerId",
                table: "StreamServers");

            migrationBuilder.DropForeignKey(
                name: "FK_StreamServers_Streams_StreamId",
                table: "StreamServers");

            migrationBuilder.AddForeignKey(
                name: "FK_BouquetStreams_Bouquets_BouquetId",
                table: "BouquetStreams",
                column: "BouquetId",
                principalTable: "Bouquets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BouquetStreams_Streams_StreamId",
                table: "BouquetStreams",
                column: "StreamId",
                principalTable: "Streams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StreamServers_Servers_ServerId",
                table: "StreamServers",
                column: "ServerId",
                principalTable: "Servers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StreamServers_Streams_StreamId",
                table: "StreamServers",
                column: "StreamId",
                principalTable: "Streams",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BouquetStreams_Bouquets_BouquetId",
                table: "BouquetStreams");

            migrationBuilder.DropForeignKey(
                name: "FK_BouquetStreams_Streams_StreamId",
                table: "BouquetStreams");

            migrationBuilder.DropForeignKey(
                name: "FK_StreamServers_Servers_ServerId",
                table: "StreamServers");

            migrationBuilder.DropForeignKey(
                name: "FK_StreamServers_Streams_StreamId",
                table: "StreamServers");

            migrationBuilder.AddForeignKey(
                name: "FK_BouquetStreams_Bouquets_BouquetId",
                table: "BouquetStreams",
                column: "BouquetId",
                principalTable: "Bouquets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BouquetStreams_Streams_StreamId",
                table: "BouquetStreams",
                column: "StreamId",
                principalTable: "Streams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StreamServers_Servers_ServerId",
                table: "StreamServers",
                column: "ServerId",
                principalTable: "Servers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StreamServers_Streams_StreamId",
                table: "StreamServers",
                column: "StreamId",
                principalTable: "Streams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
