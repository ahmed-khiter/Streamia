using Microsoft.EntityFrameworkCore.Migrations;

namespace Streamia.Migrations
{
    public partial class updateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Streams_Categories_CategoryId",
                table: "Streams");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Streams",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Streams_Categories_CategoryId",
                table: "Streams",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Streams_Categories_CategoryId",
                table: "Streams");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Streams",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Streams_Categories_CategoryId",
                table: "Streams",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
