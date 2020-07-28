using Microsoft.EntityFrameworkCore.Migrations;

namespace Streamia.Migrations
{
    public partial class AddTranscodeToAllStream : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CRF",
                table: "Transcodes",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TranscodeId",
                table: "Streams",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TranscodeId",
                table: "Serieses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TranscodeId",
                table: "Movies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Streams_TranscodeId",
                table: "Streams",
                column: "TranscodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Serieses_TranscodeId",
                table: "Serieses",
                column: "TranscodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_TranscodeId",
                table: "Movies",
                column: "TranscodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Transcodes_TranscodeId",
                table: "Movies",
                column: "TranscodeId",
                principalTable: "Transcodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Serieses_Transcodes_TranscodeId",
                table: "Serieses",
                column: "TranscodeId",
                principalTable: "Transcodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Streams_Transcodes_TranscodeId",
                table: "Streams",
                column: "TranscodeId",
                principalTable: "Transcodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Transcodes_TranscodeId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Serieses_Transcodes_TranscodeId",
                table: "Serieses");

            migrationBuilder.DropForeignKey(
                name: "FK_Streams_Transcodes_TranscodeId",
                table: "Streams");

            migrationBuilder.DropIndex(
                name: "IX_Streams_TranscodeId",
                table: "Streams");

            migrationBuilder.DropIndex(
                name: "IX_Serieses_TranscodeId",
                table: "Serieses");

            migrationBuilder.DropIndex(
                name: "IX_Movies_TranscodeId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "TranscodeId",
                table: "Streams");

            migrationBuilder.DropColumn(
                name: "TranscodeId",
                table: "Serieses");

            migrationBuilder.DropColumn(
                name: "TranscodeId",
                table: "Movies");

            migrationBuilder.AlterColumn<string>(
                name: "CRF",
                table: "Transcodes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
