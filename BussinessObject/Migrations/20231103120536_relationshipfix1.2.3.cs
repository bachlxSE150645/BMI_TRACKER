using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BussinessObject.Migrations
{
    /// <inheritdoc />
    public partial class relationshipfix123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_feedbacks_users_usersuserId",
                table: "feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_menus_categories_categorysCategoryId",
                table: "menus");

            migrationBuilder.DropColumn(
                name: "category",
                table: "menus");

            migrationBuilder.RenameColumn(
                name: "categorysCategoryId",
                table: "menus",
                newName: "categoryId");

            migrationBuilder.RenameIndex(
                name: "IX_menus_categorysCategoryId",
                table: "menus",
                newName: "IX_menus_categoryId");

            migrationBuilder.RenameColumn(
                name: "usersuserId",
                table: "feedbacks",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_feedbacks_usersuserId",
                table: "feedbacks",
                newName: "IX_feedbacks_userId");

            migrationBuilder.AddForeignKey(
                name: "FK_feedbacks_users_userId",
                table: "feedbacks",
                column: "userId",
                principalTable: "users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_menus_categories_categoryId",
                table: "menus",
                column: "categoryId",
                principalTable: "categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_feedbacks_users_userId",
                table: "feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_menus_categories_categoryId",
                table: "menus");

            migrationBuilder.RenameColumn(
                name: "categoryId",
                table: "menus",
                newName: "categorysCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_menus_categoryId",
                table: "menus",
                newName: "IX_menus_categorysCategoryId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "feedbacks",
                newName: "usersuserId");

            migrationBuilder.RenameIndex(
                name: "IX_feedbacks_userId",
                table: "feedbacks",
                newName: "IX_feedbacks_usersuserId");

            migrationBuilder.AddColumn<Guid>(
                name: "category",
                table: "menus",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_feedbacks_users_usersuserId",
                table: "feedbacks",
                column: "usersuserId",
                principalTable: "users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_menus_categories_categorysCategoryId",
                table: "menus",
                column: "categorysCategoryId",
                principalTable: "categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
