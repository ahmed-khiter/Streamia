using Microsoft.EntityFrameworkCore.Migrations;

namespace Streamia.Migrations
{
    public partial class EditTable : Migration
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
                keyValue: 1297);

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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryType", "Name" },
                values: new object[,]
                {
                    { 39469, 1, "Adventure" },
                    { 9962, 2, "Suspense" },
                    { 3320, 2, "Thriller" },
                    { 5178, 2, "Horror" },
                    { 4627, 2, "Romance" },
                    { 2539, 2, "Animation" },
                    { 4821, 2, "Anime" },
                    { 6602, 2, "Mini-Series" },
                    { 3969, 2, "Family" },
                    { 1730, 2, "Historical" },
                    { 8469, 2, "Children" },
                    { 3966, 2, "Reality" },
                    { 4594, 2, "Mystery" },
                    { 840, 2, "Documentary" },
                    { 6479, 2, "political" },
                    { 8600, 2, "Soap" },
                    { 5949, 2, "Sport" },
                    { 2281, 2, "Western" },
                    { 5090, 2, "saga" },
                    { 9026, 2, "Crime Thriller" },
                    { 2185, 2, "Disaster Thriller" },
                    { 1264, 2, "Psychological Thriller" },
                    { 3551, 2, "Techno Thriller" },
                    { 1002, 0, "Science" },
                    { 900, 2, "Science Fiction" },
                    { 8815, 0, "ACtion" },
                    { 9417, 2, "Fantasy" },
                    { 7606, 2, "Adventure" },
                    { 472, 1, "Comedy" },
                    { 3350, 1, "Crime" },
                    { 4225, 1, "Drama" },
                    { 7886, 1, "Fantasy" },
                    { 8032, 1, "Historical" },
                    { 935, 1, "Horror" },
                    { 8313, 1, "Mystery" },
                    { 7291, 1, "philosophical" },
                    { 146, 1, "political" },
                    { 6191, 1, "Romance" },
                    { 369, 1, "saga" },
                    { 5967, 1, "Thriller" },
                    { 9921, 1, "Western" },
                    { 1359, 1, "Crime Thriller" },
                    { 9342, 1, "Disaster Thriller" },
                    { 2588, 1, "Psychological Thriller" },
                    { 8019, 1, "Techno Thriller" },
                    { 5482, 1, "Science Fiction" },
                    { 2776, 1, "Suspense" },
                    { 1371, 1, "Animation" },
                    { 5478, 2, "Drama" },
                    { 3618, 2, "Action" },
                    { 5422, 2, "Comedy" },
                    { 4664, 2, "Crime" },
                    { 7666, 0, "News" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 369);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 472);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 840);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 900);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 935);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1002);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1264);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1359);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1371);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1730);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2185);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2281);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2539);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2588);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2776);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3320);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3350);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3551);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3618);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3966);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3969);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4225);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4594);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4627);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4664);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4821);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5090);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5178);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5422);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5478);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5482);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5949);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5967);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6191);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6479);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6602);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7291);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7606);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7666);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7886);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8019);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8032);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8313);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8469);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8600);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8815);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9026);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9342);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9417);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9921);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9962);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 39469);

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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryType", "Name" },
                values: new object[,]
                {
                    { 61442, 1, "Adventure" },
                    { 513, 2, "Suspense" },
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
                    { 4292, 2, "Science Fiction" },
                    { 9522, 0, "ACtion" },
                    { 6072, 2, "Fantasy" },
                    { 4062, 2, "Adventure" },
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
                    { 1297, 2, "Action" },
                    { 6643, 2, "Comedy" },
                    { 7136, 2, "Crime" },
                    { 2673, 0, "News" }
                });
        }
    }
}
