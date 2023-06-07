using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SoccerLeague.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Season",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Season", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HomeTeamId = table.Column<int>(type: "int", nullable: false),
                    HomeTeamScore = table.Column<int>(type: "int", nullable: true),
                    AwayTeamId = table.Column<int>(type: "int", nullable: false),
                    AwayTeamScore = table.Column<int>(type: "int", nullable: true),
                    SeasonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Match_Season_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Season",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Match_Team_AwayTeamId",
                        column: x => x.AwayTeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Match_Team_HomeTeamId",
                        column: x => x.HomeTeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SeasonTeamBridge",
                columns: table => new
                {
                    SeasonId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeasonTeamBridge", x => new { x.SeasonId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_SeasonTeamBridge_Season_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Season",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SeasonTeamBridge_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Season",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "2021 Summer" },
                    { 2, "2021 Fall" },
                    { 3, "2021 Winter 1" },
                    { 4, "2021 Winter 2" },
                    { 5, "2022 Summer" },
                    { 6, "2022 Fall" },
                    { 7, "2022 Winter 1" },
                    { 8, "2022 Winter 2" },
                    { 9, "2023 Summer" }
                });

            migrationBuilder.InsertData(
                table: "Team",
                columns: new[] { "Id", "Color", "Name" },
                values: new object[,]
                {
                    { 1, "Gold", "Goal Diggers" },
                    { 2, null, "Saigon FC" },
                    { 3, null, "UmBros" },
                    { 4, null, "Internationals" },
                    { 5, "Red", "Liverpool" },
                    { 6, null, "Deportivo Argento" },
                    { 7, null, "Noonan" },
                    { 8, null, "Ajax" },
                    { 9, null, "Reds FC" },
                    { 10, null, "Nile Crocodiles" },
                    { 11, null, "Unreal" }
                });

            migrationBuilder.InsertData(
                table: "Match",
                columns: new[] { "Id", "AwayTeamId", "AwayTeamScore", "HomeTeamId", "HomeTeamScore", "SeasonId", "Start" },
                values: new object[,]
                {
                    { 1, 3, 2, 1, 6, 9, new DateTime(2023, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 5, 4, 2, 5, 9, new DateTime(2023, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 6, 0, 4, 2, 9, new DateTime(2023, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 5, 4, 1, 3, 9, new DateTime(2023, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 3, 5, 6, 1, 9, new DateTime(2023, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 2, 3, 4, 2, 9, new DateTime(2023, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 11, 3, 1, 3, 8, new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "SeasonTeamBridge",
                columns: new[] { "SeasonId", "TeamId" },
                values: new object[,]
                {
                    { 8, 1 },
                    { 8, 3 },
                    { 8, 6 },
                    { 8, 7 },
                    { 8, 8 },
                    { 8, 9 },
                    { 8, 10 },
                    { 8, 11 },
                    { 9, 1 },
                    { 9, 2 },
                    { 9, 3 },
                    { 9, 4 },
                    { 9, 5 },
                    { 9, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Match_AwayTeamId",
                table: "Match",
                column: "AwayTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_HomeTeamId",
                table: "Match",
                column: "HomeTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_SeasonId",
                table: "Match",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_SeasonTeamBridge_TeamId",
                table: "SeasonTeamBridge",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "SeasonTeamBridge");

            migrationBuilder.DropTable(
                name: "Season");

            migrationBuilder.DropTable(
                name: "Team");
        }
    }
}
