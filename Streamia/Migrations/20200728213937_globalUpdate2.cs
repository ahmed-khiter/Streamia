using Microsoft.EntityFrameworkCore.Migrations;

namespace Streamia.Migrations
{
    public partial class globalUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Channels_Categories_CategoryId",
                table: "Channels");

            migrationBuilder.DropIndex(
                name: "IX_Channels_CategoryId",
                table: "Channels");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Channels");

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Channels");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Channels");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Channels");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "Channels");

            migrationBuilder.DropColumn(
                name: "StartChannel",
                table: "Channels");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Channels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Channels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Channels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Channels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Channels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "StartChannel",
                table: "Channels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Channels_CategoryId",
                table: "Channels",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Channels_Categories_CategoryId",
                table: "Channels",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
