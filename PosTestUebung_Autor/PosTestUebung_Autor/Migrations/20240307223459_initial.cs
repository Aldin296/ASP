using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PosTestUebung_Autor.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autoren",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autoren", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Buecher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Genres = table.Column<string>(type: "TEXT", nullable: false),
                    Pagecount = table.Column<int>(type: "INTEGER", nullable: false),
                    Stars = table.Column<int>(type: "INTEGER", nullable: false),
                    AutorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buecher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buecher_Autoren_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Autoren",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buecher_AutorId",
                table: "Buecher",
                column: "AutorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buecher");

            migrationBuilder.DropTable(
                name: "Autoren");
        }
    }
}
