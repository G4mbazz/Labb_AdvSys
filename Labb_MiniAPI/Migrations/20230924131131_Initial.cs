using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Labb_MiniAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishingYear = table.Column<int>(type: "int", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ID", "Author", "Description", "Genre", "PublishingYear", "Stock", "Title" },
                values: new object[,]
                {
                    { 1, "George B", "Description", "History", 2003, 51, "Twice They Fall" },
                    { 2, "Lyndon B.J", "Description", "Thriller", 1968, 14, "The Whispering Trees" },
                    { 3, "Me", "Description.txt", "Comedy", 1569, 0, "How To Be Funny" },
                    { 4, "Sara Andersson", "Description", "Horror", 2021, 7, "Mörkret" },
                    { 5, "Sara Andersson", "Description", "Romance", 2015, 34, "Gatuköket" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
