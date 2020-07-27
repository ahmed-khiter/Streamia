using Microsoft.EntityFrameworkCore.Migrations;

namespace Streamia.Migrations
{
    public partial class addTableTranscode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transcodes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    VideoCodec = table.Column<string>(nullable: true),
                    AudioCodec = table.Column<string>(nullable: true),
                    AvgAudioBitrate = table.Column<string>(nullable: true),
                    MinBitrate = table.Column<string>(nullable: true),
                    MaxBitrate = table.Column<string>(nullable: true),
                    AvgBitrate = table.Column<string>(nullable: true),
                    BufferSize = table.Column<string>(nullable: true),
                    CRF = table.Column<string>(nullable: true),
                    Preset = table.Column<string>(nullable: true),
                    Scaling = table.Column<string>(nullable: true),
                    AspectRatio = table.Column<string>(nullable: true),
                    AudioSampleRate = table.Column<string>(nullable: true),
                    TranscodeState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transcodes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transcodes");
        }
    }
}
