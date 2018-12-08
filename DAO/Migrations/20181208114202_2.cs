using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAO.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImagesLikes_AspNetUsers_ApplicationUserId",
                table: "ImagesLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_ImagesLikes_AspNetUsers_UserWhoLikedId",
                table: "ImagesLikes");

            migrationBuilder.DropIndex(
                name: "IX_ImagesLikes_ApplicationUserId",
                table: "ImagesLikes");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "ImagesLikes");

            migrationBuilder.RenameColumn(
                name: "UserWhoLikedId",
                table: "ImagesLikes",
                newName: "UserWhoLikedID");

            migrationBuilder.RenameIndex(
                name: "IX_ImagesLikes_UserWhoLikedId",
                table: "ImagesLikes",
                newName: "IX_ImagesLikes_UserWhoLikedID");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserWhoLikedID",
                table: "ImagesLikes",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ImagesLikes_AspNetUsers_UserWhoLikedID",
                table: "ImagesLikes",
                column: "UserWhoLikedID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImagesLikes_AspNetUsers_UserWhoLikedID",
                table: "ImagesLikes");

            migrationBuilder.RenameColumn(
                name: "UserWhoLikedID",
                table: "ImagesLikes",
                newName: "UserWhoLikedId");

            migrationBuilder.RenameIndex(
                name: "IX_ImagesLikes_UserWhoLikedID",
                table: "ImagesLikes",
                newName: "IX_ImagesLikes_UserWhoLikedId");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserWhoLikedId",
                table: "ImagesLikes",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationUserId",
                table: "ImagesLikes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImagesLikes_ApplicationUserId",
                table: "ImagesLikes",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImagesLikes_AspNetUsers_ApplicationUserId",
                table: "ImagesLikes",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ImagesLikes_AspNetUsers_UserWhoLikedId",
                table: "ImagesLikes",
                column: "UserWhoLikedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
