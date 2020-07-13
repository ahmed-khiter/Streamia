using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Streamia.Migrations
{
    public partial class updateIptvUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subscription",
                table: "IptvUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "IptvUsers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Connections",
                table: "IptvUsers",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "Expiration",
                table: "IptvUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Connections",
                table: "IptvUsers");

            migrationBuilder.DropColumn(
                name: "Expiration",
                table: "IptvUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "IptvUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<long>(
                name: "Subscription",
                table: "IptvUsers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
