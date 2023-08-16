using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository_Pattern.Migrations
{
    public partial class AddTable0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "autherss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_autherss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "bookss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    AutherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bookss_autherss_AutherId",
                        column: x => x.AutherId,
                        principalTable: "autherss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookss_AutherId",
                table: "bookss",
                column: "AutherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookss");

            migrationBuilder.DropTable(
                name: "autherss");
        }
    }
}
