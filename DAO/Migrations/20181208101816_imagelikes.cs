using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAO.Migrations
{
    public partial class imagelikes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImagesLikes",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ImageID = table.Column<Guid>(nullable: false),
                    WhoLikedID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagesLikes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ImagesLikes_Images_ImageID",
                        column: x => x.ImageID,
                        principalTable: "Images",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImagesLikes_AspNetUsers_WhoLikedID",
                        column: x => x.WhoLikedID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImagesLikes_ImageID",
                table: "ImagesLikes",
                column: "ImageID");

            migrationBuilder.CreateIndex(
                name: "IX_ImagesLikes_WhoLikedID",
                table: "ImagesLikes",
                column: "WhoLikedID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImagesLikes");
        }
    }
}
