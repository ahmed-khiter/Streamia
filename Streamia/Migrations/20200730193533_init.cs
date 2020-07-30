using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Streamia.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ProfilePicture = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bouquets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bouquets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryType = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Channels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Channels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Ip = table.Column<string>(nullable: false),
                    RootPassword = table.Column<string>(nullable: false),
                    MaxClients = table.Column<int>(nullable: false),
                    HttpPort = table.Column<int>(nullable: false),
                    HttpsPort = table.Column<int>(nullable: false),
                    SshPort = table.Column<int>(nullable: false),
                    RtmpPort = table.Column<int>(nullable: false),
                    IsRTMP = table.Column<bool>(nullable: false),
                    ServerState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servers", x => x.Id);
                });

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
                    MinBitrate = table.Column<int>(nullable: false),
                    MaxBitrate = table.Column<int>(nullable: false),
                    AvgBitrate = table.Column<int>(nullable: false),
                    BufferSize = table.Column<string>(nullable: true),
                    CRF = table.Column<int>(nullable: false),
                    Preset = table.Column<int>(nullable: false),
                    Tune = table.Column<int>(nullable: false),
                    Scaling = table.Column<string>(nullable: true),
                    AspectRatio = table.Column<string>(nullable: true),
                    TargetVideoFrameRate = table.Column<string>(nullable: true),
                    AudioChannel = table.Column<int>(nullable: false),
                    RemoveSensitiveParts = table.Column<string>(nullable: true),
                    Threads = table.Column<int>(nullable: false),
                    AudioSampleRate = table.Column<string>(nullable: true),
                    Hardware = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transcodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    AdminUserId = table.Column<string>(nullable: false),
                    UserValue = table.Column<int>(nullable: false),
                    UnitPoint = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    SetAccountKey = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.AdminUserId);
                    table.ForeignKey(
                        name: "FK_Settings_AspNetUsers_AdminUserId",
                        column: x => x.AdminUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "IptvUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Connections = table.Column<long>(nullable: false),
                    DaysToExpire = table.Column<long>(nullable: false),
                    Expiration = table.Column<DateTime>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    BouquetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IptvUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IptvUsers_Bouquets_BouquetId",
                        column: x => x.BouquetId,
                        principalTable: "Bouquets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreamKey = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    TranscodeId = table.Column<int>(nullable: false),
                    StreamDirectly = table.Column<bool>(nullable: false),
                    Uptime = table.Column<DateTime>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Overview = table.Column<string>(nullable: true),
                    PosterUrl = table.Column<string>(nullable: true),
                    Cast = table.Column<string>(nullable: true),
                    Director = table.Column<string>(nullable: true),
                    Gener = table.Column<string>(nullable: true),
                    ReleaseDate = table.Column<string>(nullable: true),
                    Runtime = table.Column<int>(nullable: false),
                    Rating = table.Column<float>(nullable: false),
                    Source = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movies_Transcodes_TranscodeId",
                        column: x => x.TranscodeId,
                        principalTable: "Transcodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Serieses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreamKey = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    TranscodeId = table.Column<int>(nullable: false),
                    StreamDirectly = table.Column<bool>(nullable: false),
                    Uptime = table.Column<DateTime>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Overview = table.Column<string>(nullable: true),
                    PosterUrl = table.Column<string>(nullable: true),
                    Cast = table.Column<string>(nullable: true),
                    Gener = table.Column<string>(nullable: true),
                    ReleaseDate = table.Column<string>(nullable: true),
                    Rating = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serieses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Serieses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Serieses_Transcodes_TranscodeId",
                        column: x => x.TranscodeId,
                        principalTable: "Transcodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Streams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreamKey = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    TranscodeId = table.Column<int>(nullable: false),
                    StreamDirectly = table.Column<bool>(nullable: false),
                    Uptime = table.Column<DateTime>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Source = table.Column<string>(nullable: false),
                    GeneratePts = table.Column<bool>(nullable: false),
                    EnableRtmp = table.Column<bool>(nullable: false),
                    EnableRecording = table.Column<bool>(nullable: false),
                    EnigmaSID = table.Column<string>(nullable: true),
                    Delay = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Streams_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Streams_Transcodes_TranscodeId",
                        column: x => x.TranscodeId,
                        principalTable: "Transcodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BouquetMovies",
                columns: table => new
                {
                    BouquetId = table.Column<int>(nullable: false),
                    MovieId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BouquetMovies", x => new { x.BouquetId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_BouquetMovies_Bouquets_BouquetId",
                        column: x => x.BouquetId,
                        principalTable: "Bouquets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BouquetMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MovieServers",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false),
                    ServerId = table.Column<int>(nullable: false),
                    Pid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieServers", x => new { x.MovieId, x.ServerId });
                    table.ForeignKey(
                        name: "FK_MovieServers_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MovieServers_Servers_ServerId",
                        column: x => x.ServerId,
                        principalTable: "Servers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BouquetSeries",
                columns: table => new
                {
                    BouquetId = table.Column<int>(nullable: false),
                    SeriesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BouquetSeries", x => new { x.BouquetId, x.SeriesId });
                    table.ForeignKey(
                        name: "FK_BouquetSeries_Bouquets_BouquetId",
                        column: x => x.BouquetId,
                        principalTable: "Bouquets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BouquetSeries_Serieses_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Serieses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Episode",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeriesId = table.Column<int>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    Season = table.Column<int>(nullable: false),
                    Source = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Overview = table.Column<string>(nullable: true),
                    Director = table.Column<string>(nullable: true),
                    ReleaseDate = table.Column<string>(nullable: true),
                    Rating = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Episode_Serieses_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Serieses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeriesServers",
                columns: table => new
                {
                    SeriesId = table.Column<int>(nullable: false),
                    ServerId = table.Column<int>(nullable: false),
                    Pid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesServers", x => new { x.SeriesId, x.ServerId });
                    table.ForeignKey(
                        name: "FK_SeriesServers_Serieses_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Serieses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SeriesServers_Servers_ServerId",
                        column: x => x.ServerId,
                        principalTable: "Servers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BouquetStreams",
                columns: table => new
                {
                    BouquetId = table.Column<int>(nullable: false),
                    StreamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BouquetStreams", x => new { x.BouquetId, x.StreamId });
                    table.ForeignKey(
                        name: "FK_BouquetStreams_Bouquets_BouquetId",
                        column: x => x.BouquetId,
                        principalTable: "Bouquets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BouquetStreams_Streams_StreamId",
                        column: x => x.StreamId,
                        principalTable: "Streams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StreamServers",
                columns: table => new
                {
                    StreamId = table.Column<int>(nullable: false),
                    ServerId = table.Column<int>(nullable: false),
                    Pid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StreamServers", x => new { x.StreamId, x.ServerId });
                    table.ForeignKey(
                        name: "FK_StreamServers_Servers_ServerId",
                        column: x => x.ServerId,
                        principalTable: "Servers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StreamServers_Streams_StreamId",
                        column: x => x.StreamId,
                        principalTable: "Streams",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryType", "Name" },
                values: new object[,]
                {
                    { 1, 0, "Science" },
                    { 27, 2, "Comedy" },
                    { 28, 2, "Crime" },
                    { 29, 2, "Drama" },
                    { 30, 2, "Fantasy" },
                    { 31, 2, "Historical" },
                    { 32, 2, "Horror" },
                    { 33, 2, "Mystery" },
                    { 34, 2, "Philosophical" },
                    { 35, 2, "Political" },
                    { 36, 2, "Saga" },
                    { 37, 2, "Thriller" },
                    { 38, 2, "Western" },
                    { 39, 2, "Crime Thriller" },
                    { 40, 2, "Disaster Thriller" },
                    { 41, 2, "Psychological Thriller" },
                    { 42, 2, "Techno Thriller" },
                    { 43, 2, "Science Fiction" },
                    { 44, 2, "Suspense" },
                    { 45, 2, "Animation" },
                    { 46, 2, "Documentary" },
                    { 47, 2, "Family" },
                    { 26, 2, "Adventure" },
                    { 48, 2, "Children" },
                    { 25, 2, "Action" },
                    { 23, 1, "Suspense" },
                    { 2, 0, "Action" },
                    { 3, 0, "News" },
                    { 4, 1, "Action" },
                    { 5, 1, "Adventure" },
                    { 6, 1, "Comedy" },
                    { 7, 1, "Crime" },
                    { 8, 1, "Drama" },
                    { 9, 1, "Fantasy" },
                    { 10, 1, "Historical" },
                    { 11, 1, "Horror" },
                    { 12, 1, "Mystery" },
                    { 13, 1, "Philosophical" },
                    { 14, 1, "Political" },
                    { 15, 1, "Saga" },
                    { 16, 1, "Thriller" },
                    { 17, 1, "Western" },
                    { 18, 1, "Crime Thriller" },
                    { 19, 1, "Disaster Thriller" },
                    { 20, 1, "Psychological Thriller" },
                    { 21, 1, "Techno Thriller" },
                    { 22, 1, "Science Fiction" },
                    { 24, 1, "Animation" },
                    { 49, 2, "Sport" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BouquetMovies_MovieId",
                table: "BouquetMovies",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_BouquetSeries_SeriesId",
                table: "BouquetSeries",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_BouquetStreams_StreamId",
                table: "BouquetStreams",
                column: "StreamId");

            migrationBuilder.CreateIndex(
                name: "IX_Episode_SeriesId",
                table: "Episode",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_IptvUsers_BouquetId",
                table: "IptvUsers",
                column: "BouquetId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CategoryId",
                table: "Movies",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_TranscodeId",
                table: "Movies",
                column: "TranscodeId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieServers_ServerId",
                table: "MovieServers",
                column: "ServerId");

            migrationBuilder.CreateIndex(
                name: "IX_Serieses_CategoryId",
                table: "Serieses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Serieses_TranscodeId",
                table: "Serieses",
                column: "TranscodeId");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesServers_ServerId",
                table: "SeriesServers",
                column: "ServerId");

            migrationBuilder.CreateIndex(
                name: "IX_Streams_CategoryId",
                table: "Streams",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Streams_TranscodeId",
                table: "Streams",
                column: "TranscodeId");

            migrationBuilder.CreateIndex(
                name: "IX_StreamServers_ServerId",
                table: "StreamServers",
                column: "ServerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BouquetMovies");

            migrationBuilder.DropTable(
                name: "BouquetSeries");

            migrationBuilder.DropTable(
                name: "BouquetStreams");

            migrationBuilder.DropTable(
                name: "Channels");

            migrationBuilder.DropTable(
                name: "Episode");

            migrationBuilder.DropTable(
                name: "IptvUsers");

            migrationBuilder.DropTable(
                name: "MovieServers");

            migrationBuilder.DropTable(
                name: "SeriesServers");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "StreamServers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Bouquets");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Serieses");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Servers");

            migrationBuilder.DropTable(
                name: "Streams");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Transcodes");
        }
    }
}
