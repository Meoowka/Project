using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Programm_L.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Book_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_book = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name_author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Janr_book = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kol_vo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Book_ID);
                });

            migrationBuilder.CreateTable(
                name: "Library_l",
                columns: table => new
                {
                    Lib_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_lib = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code_lib = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Library_l", x => x.Lib_ID);
                });

            migrationBuilder.CreateTable(
                name: "Personal",
                columns: table => new
                {
                    Personal_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_pers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Staj_pers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personal", x => x.Personal_ID);
                });

            migrationBuilder.CreateTable(
                name: "Extradition",
                columns: table => new
                {
                    Extra_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Personal_ID = table.Column<int>(type: "int", nullable: false),
                    Book_ID = table.Column<int>(type: "int", nullable: false),
                    Data_extra = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extradition", x => x.Extra_ID);
                    table.ForeignKey(
                        name: "FK_Extradition_Books_Book_ID",
                        column: x => x.Book_ID,
                        principalTable: "Books",
                        principalColumn: "Book_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Extradition_Personal_Personal_ID",
                        column: x => x.Personal_ID,
                        principalTable: "Personal",
                        principalColumn: "Personal_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Extradition_Book_ID",
                table: "Extradition",
                column: "Book_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Extradition_Personal_ID",
                table: "Extradition",
                column: "Personal_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Extradition");

            migrationBuilder.DropTable(
                name: "Library_l");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Personal");
        }
    }
}
