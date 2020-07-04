using Microsoft.EntityFrameworkCore.Migrations;

namespace Streamia.Migrations
{
    public partial class addSourceType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SourceType",
                table: "SourceServers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SourceType",
                table: "BouquetSources",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SourceType",
                table: "SourceServers");

            migrationBuilder.DropColumn(
                name: "SourceType",
                table: "BouquetSources");
        }
    }
}
