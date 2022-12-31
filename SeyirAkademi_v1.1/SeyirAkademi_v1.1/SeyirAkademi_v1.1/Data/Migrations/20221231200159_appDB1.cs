using Microsoft.EntityFrameworkCore.Migrations;

namespace SeyirAkademi_v1._1.Data.Migrations
{
    public partial class appDB1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserAd",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserSoyad",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserAd",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserSoyad",
                table: "AspNetUsers");
        }
    }
}
