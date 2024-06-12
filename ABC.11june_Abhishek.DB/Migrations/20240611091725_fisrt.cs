using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ABC._11june_Abhishek.DB.Migrations
{
    public partial class fisrt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Singer",
                columns: table => new
                {
                    SingerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Singer", x => x.SingerId);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    SongId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Song = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.SongId);
                });

            migrationBuilder.CreateTable(
                name: "SungBy",
                columns: table => new
                {
                    SungById = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SingerId = table.Column<int>(type: "int", nullable: false),
                    SongId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SungBy", x => x.SungById);
                    table.ForeignKey(
                        name: "FK_SungBy_Singer_SingerId",
                        column: x => x.SingerId,
                        principalTable: "Singer",
                        principalColumn: "SingerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SungBy_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "SongId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SungBy_SingerId",
                table: "SungBy",
                column: "SingerId");

            migrationBuilder.CreateIndex(
                name: "IX_SungBy_SongId",
                table: "SungBy",
                column: "SongId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SungBy");

            migrationBuilder.DropTable(
                name: "Singer");

            migrationBuilder.DropTable(
                name: "Songs");
        }
    }
}
