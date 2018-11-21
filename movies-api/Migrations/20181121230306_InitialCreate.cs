using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    Year = table.Column<string>(nullable: true),
                    Runtime = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: true),
                    Director = table.Column<string>(nullable: true),
                    Plot = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    PosterLink = table.Column<string>(nullable: true),
                    ImdbRating = table.Column<string>(nullable: true),
                    DateCreated = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieItem", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieItem");
        }
    }
}
