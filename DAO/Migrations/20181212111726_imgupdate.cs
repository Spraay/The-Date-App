using Microsoft.EntityFrameworkCore.Migrations;

namespace DAO.Migrations
{
    public partial class imgupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BackgroundImageSrc",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackgroundImageSrc",
                table: "AspNetUsers");
        }
    }
}
