using Microsoft.EntityFrameworkCore.Migrations;

namespace Carte2ct_Final.Migrations
{
    public partial class GameList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                    table.ForeignKey(
                        name: "FK_Games_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "Name" },
                values: new object[,]
                {
                    { "A", "Action" },
                    { "AA", "Adventure" },
                    { "R", "RPG" },
                    { "S", "Strategy" },
                    { "M", "MMO" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameId", "GenreId", "Name", "Rating", "Year" },
                values: new object[] { 2, "A", "Halo", 3, 2001 });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameId", "GenreId", "Name", "Rating", "Year" },
                values: new object[] { 4, "AA", "Doom", 5, 1993 });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameId", "GenreId", "Name", "Rating", "Year" },
                values: new object[] { 3, "S", "Sonic", 4, 1991 });

            migrationBuilder.CreateIndex(
                name: "IX_Games_GenreId",
                table: "Games",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
