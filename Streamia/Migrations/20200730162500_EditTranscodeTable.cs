using Microsoft.EntityFrameworkCore.Migrations;

namespace Streamia.Migrations
{
    public partial class EditTranscodeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 362);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 383);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 487);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 513);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 573);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 760);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1331);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1353);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1467);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1719);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2067);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2673);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2752);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3091);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3135);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3219);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3330);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3527);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3920);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4062);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4198);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4292);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4499);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4743);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5007);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5406);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5593);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5884);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6072);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6150);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6293);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6436);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6643);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7051);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7136);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7347);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7355);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7367);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7667);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7825);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7834);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7836);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7921);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8386);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8466);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8732);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9375);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9522);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9643);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9724);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9731);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 61442);

            migrationBuilder.AlterColumn<int>(
                name: "Preset",
                table: "Transcodes",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MinBitrate",
                table: "Transcodes",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaxBitrate",
                table: "Transcodes",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AvgBitrate",
                table: "Transcodes",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AudioChannel",
                table: "Transcodes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RemoveSenstitveParts",
                table: "Transcodes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TargetVideoFrameRate",
                table: "Transcodes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Threads",
                table: "Transcodes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Tune",
                table: "Transcodes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1297,
                columns: new[] { "CategoryType", "Name" },
                values: new object[] { 1, "Animation" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryType", "Name" },
                values: new object[,]
                {
                    { 5909, 2, "Thriller" },
                    { 1820, 2, "Horror" },
                    { 4041, 2, "Romance" },
                    { 6489, 2, "Animation" },
                    { 8794, 2, "Anime" },
                    { 6190, 2, "Mini-Series" },
                    { 440, 2, "Family" },
                    { 1629, 2, "Historical" },
                    { 6944, 2, "Children" },
                    { 10, 2, "Reality" },
                    { 8203, 2, "Mystery" },
                    { 4637, 2, "Documentary" },
                    { 8680, 2, "political" },
                    { 2405, 2, "Soap" },
                    { 9127, 2, "Sport" },
                    { 1674, 2, "Western" },
                    { 8478, 2, "saga" },
                    { 5975, 2, "Crime Thriller" },
                    { 5001, 2, "Disaster Thriller" },
                    { 255, 2, "Psychological Thriller" },
                    { 3323, 2, "Techno Thriller" },
                    { 6263, 0, "Science" },
                    { 6754, 0, "ACtion" },
                    { 7011, 2, "Suspense" },
                    { 5899, 0, "News" },
                    { 190, 2, "Science Fiction" },
                    { 1333, 2, "Crime" },
                    { 8142, 1, "Comedy" },
                    { 4117, 1, "Crime" },
                    { 1608, 1, "Drama" },
                    { 7872, 1, "Fantasy" },
                    { 3305, 1, "Historical" },
                    { 311, 1, "Horror" },
                    { 4661, 1, "Mystery" },
                    { 446, 1, "philosophical" },
                    { 5492, 1, "political" },
                    { 9139, 1, "Romance" },
                    { 3084, 1, "saga" },
                    { 798, 1, "Thriller" },
                    { 575, 1, "Western" },
                    { 6811, 1, "Crime Thriller" },
                    { 2269, 1, "Disaster Thriller" },
                    { 2706, 1, "Psychological Thriller" },
                    { 8891, 1, "Techno Thriller" },
                    { 7959, 1, "Science Fiction" },
                    { 2742, 1, "Suspense" },
                    { 3325, 2, "Drama" },
                    { 427, 2, "Action" },
                    { 8767, 2, "Comedy" },
                    { 30, 2, "Adventure" },
                    { 679, 2, "Fantasy" },
                    { 12775, 1, "Adventure" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 255);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 311);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 427);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 440);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 446);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 575);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 679);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 798);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1333);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1608);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1629);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1674);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1820);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2269);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2405);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2706);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2742);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3084);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3305);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3323);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3325);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4041);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4117);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4637);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4661);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5001);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5492);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5899);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5909);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5975);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6190);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6263);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6489);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6754);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6811);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6944);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7011);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7872);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7959);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8142);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8203);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8478);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8680);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8767);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8794);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8891);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9127);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9139);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12775);

            migrationBuilder.DropColumn(
                name: "AudioChannel",
                table: "Transcodes");

            migrationBuilder.DropColumn(
                name: "RemoveSenstitveParts",
                table: "Transcodes");

            migrationBuilder.DropColumn(
                name: "TargetVideoFrameRate",
                table: "Transcodes");

            migrationBuilder.DropColumn(
                name: "Threads",
                table: "Transcodes");

            migrationBuilder.DropColumn(
                name: "Tune",
                table: "Transcodes");

            migrationBuilder.AlterColumn<string>(
                name: "Preset",
                table: "Transcodes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "MinBitrate",
                table: "Transcodes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "MaxBitrate",
                table: "Transcodes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "AvgBitrate",
                table: "Transcodes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1297,
                columns: new[] { "CategoryType", "Name" },
                values: new object[] { 2, "Action" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryType", "Name" },
                values: new object[,]
                {
                    { 1467, 2, "Thriller" },
                    { 6293, 2, "Horror" },
                    { 3135, 2, "Romance" },
                    { 3920, 2, "Animation" },
                    { 7347, 2, "Anime" },
                    { 4198, 2, "Mini-Series" },
                    { 383, 2, "Family" },
                    { 7836, 2, "Historical" },
                    { 9731, 2, "Children" },
                    { 7825, 2, "Reality" },
                    { 362, 2, "Mystery" },
                    { 1353, 2, "Documentary" },
                    { 5884, 2, "political" },
                    { 2067, 2, "Soap" },
                    { 4499, 2, "Sport" },
                    { 1331, 2, "Western" },
                    { 6436, 2, "saga" },
                    { 7921, 2, "Crime Thriller" },
                    { 2752, 2, "Disaster Thriller" },
                    { 8732, 2, "Psychological Thriller" },
                    { 7834, 2, "Techno Thriller" },
                    { 1719, 0, "Science" },
                    { 9522, 0, "ACtion" },
                    { 513, 2, "Suspense" },
                    { 2673, 0, "News" },
                    { 4292, 2, "Science Fiction" },
                    { 7136, 2, "Crime" },
                    { 8386, 1, "Comedy" },
                    { 6150, 1, "Crime" },
                    { 573, 1, "Drama" },
                    { 5007, 1, "Fantasy" },
                    { 7667, 1, "Historical" },
                    { 3219, 1, "Horror" },
                    { 8466, 1, "Mystery" },
                    { 9643, 1, "philosophical" },
                    { 487, 1, "political" },
                    { 4743, 1, "Romance" },
                    { 3091, 1, "saga" },
                    { 7051, 1, "Thriller" },
                    { 760, 1, "Western" },
                    { 3330, 1, "Crime Thriller" },
                    { 9724, 1, "Disaster Thriller" },
                    { 9375, 1, "Psychological Thriller" },
                    { 5406, 1, "Techno Thriller" },
                    { 7355, 1, "Science Fiction" },
                    { 5593, 1, "Suspense" },
                    { 7367, 1, "Animation" },
                    { 3527, 2, "Drama" },
                    { 6643, 2, "Comedy" },
                    { 4062, 2, "Adventure" },
                    { 6072, 2, "Fantasy" },
                    { 61442, 1, "Adventure" }
                });
        }
    }
}
