using Microsoft.EntityFrameworkCore.Migrations;

namespace Streamia.Migrations
{
    public partial class update_iptv_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersIptv_Bouquets_BouquetId",
                table: "UsersIptv");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersIptv",
                table: "UsersIptv");

            migrationBuilder.RenameTable(
                name: "UsersIptv",
                newName: "IptvUsers");

            migrationBuilder.RenameIndex(
                name: "IX_UsersIptv_BouquetId",
                table: "IptvUsers",
                newName: "IX_IptvUsers_BouquetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IptvUsers",
                table: "IptvUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IptvUsers_Bouquets_BouquetId",
                table: "IptvUsers",
                column: "BouquetId",
                principalTable: "Bouquets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IptvUsers_Bouquets_BouquetId",
                table: "IptvUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IptvUsers",
                table: "IptvUsers");

            migrationBuilder.RenameTable(
                name: "IptvUsers",
                newName: "UsersIptv");

            migrationBuilder.RenameIndex(
                name: "IX_IptvUsers_BouquetId",
                table: "UsersIptv",
                newName: "IX_UsersIptv_BouquetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersIptv",
                table: "UsersIptv",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersIptv_Bouquets_BouquetId",
                table: "UsersIptv",
                column: "BouquetId",
                principalTable: "Bouquets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
