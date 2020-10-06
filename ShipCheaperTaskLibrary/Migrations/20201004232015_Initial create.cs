using Microsoft.EntityFrameworkCore.Migrations;

namespace ShipCheaperTaskLibrary.Migrations
{
    public partial class Initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FavoriteMovies",
                columns: table => new
                {
                    ImdbID = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Runtime = table.Column<string>(nullable: true),
                    Year = table.Column<string>(nullable: true),
                    Poster = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: true),
                    Writer = table.Column<string>(nullable: true),
                    IsFavorite = table.Column<bool>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_FavoriteMovies", x => x.ImdbID); });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteMovies");
        }
    }
}