using Microsoft.EntityFrameworkCore.Migrations;

namespace SeyirAkademi_v1._1.Migrations
{
    public partial class _001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Docs_DocCategories_DocCategoryID",
                table: "Docs");

            migrationBuilder.DropTable(
                name: "DocCategories");

            migrationBuilder.DropIndex(
                name: "IX_Docs_DocCategoryID",
                table: "Docs");

            migrationBuilder.DropColumn(
                name: "DocCategoryID",
                table: "Docs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DocCategoryID",
                table: "Docs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DocCategories",
                columns: table => new
                {
                    DocCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocCategories", x => x.DocCategoryID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Docs_DocCategoryID",
                table: "Docs",
                column: "DocCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Docs_DocCategories_DocCategoryID",
                table: "Docs",
                column: "DocCategoryID",
                principalTable: "DocCategories",
                principalColumn: "DocCategoryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
