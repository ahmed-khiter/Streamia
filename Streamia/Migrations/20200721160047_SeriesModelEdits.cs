using Microsoft.EntityFrameworkCore.Migrations;

namespace Streamia.Migrations
{
    public partial class SeriesModelEdits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Episode_Categories_CategoryId1",
                table: "Episode");

            migrationBuilder.DropIndex(
                name: "IX_Episode_CategoryId1",
                table: "Episode");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "Episode");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Episode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId1",
                table: "Episode",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Episode",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Episode_CategoryId1",
                table: "Episode",
                column: "CategoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Episode_Categories_CategoryId1",
                table: "Episode",
                column: "CategoryId1",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
