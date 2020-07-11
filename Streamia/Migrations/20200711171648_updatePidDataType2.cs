using Microsoft.EntityFrameworkCore.Migrations;

namespace Streamia.Migrations
{
    public partial class updatePidDataType2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StreamServerPid_Servers_ServerId",
                table: "StreamServerPid");

            migrationBuilder.DropForeignKey(
                name: "FK_StreamServerPid_Streams_StreamId",
                table: "StreamServerPid");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StreamServerPid",
                table: "StreamServerPid");

            migrationBuilder.RenameTable(
                name: "StreamServerPid",
                newName: "StreamServerPids");

            migrationBuilder.RenameIndex(
                name: "IX_StreamServerPid_ServerId",
                table: "StreamServerPids",
                newName: "IX_StreamServerPids_ServerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StreamServerPids",
                table: "StreamServerPids",
                columns: new[] { "StreamId", "ServerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_StreamServerPids_Servers_ServerId",
                table: "StreamServerPids",
                column: "ServerId",
                principalTable: "Servers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StreamServerPids_Streams_StreamId",
                table: "StreamServerPids",
                column: "StreamId",
                principalTable: "Streams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StreamServerPids_Servers_ServerId",
                table: "StreamServerPids");

            migrationBuilder.DropForeignKey(
                name: "FK_StreamServerPids_Streams_StreamId",
                table: "StreamServerPids");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StreamServerPids",
                table: "StreamServerPids");

            migrationBuilder.RenameTable(
                name: "StreamServerPids",
                newName: "StreamServerPid");

            migrationBuilder.RenameIndex(
                name: "IX_StreamServerPids_ServerId",
                table: "StreamServerPid",
                newName: "IX_StreamServerPid_ServerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StreamServerPid",
                table: "StreamServerPid",
                columns: new[] { "StreamId", "ServerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_StreamServerPid_Servers_ServerId",
                table: "StreamServerPid",
                column: "ServerId",
                principalTable: "Servers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StreamServerPid_Streams_StreamId",
                table: "StreamServerPid",
                column: "StreamId",
                principalTable: "Streams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
