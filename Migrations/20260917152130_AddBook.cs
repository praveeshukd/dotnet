using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductCrud.Migrations
{
    /// <inheritdoc />
    public partial class AddBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Author = table.Column<string>(type: "TEXT", maxLength: 120, nullable: true),
                    Publisher = table.Column<string>(type: "TEXT", maxLength: 120, nullable: true),
                    ISBN = table.Column<string>(type: "TEXT", maxLength: 40, nullable: true),
                    Category = table.Column<string>(type: "TEXT", maxLength: 80, nullable: true),
                    SubCategory = table.Column<string>(type: "TEXT", maxLength: 80, nullable: true),
                    Language = table.Column<string>(type: "TEXT", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
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
