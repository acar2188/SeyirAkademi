using Microsoft.EntityFrameworkCore.Migrations;

namespace SeyirAkademi_v1._1.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DocTypeId",
                table: "Docs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocTypeId",
                table: "Docs");
        }
    }
}
