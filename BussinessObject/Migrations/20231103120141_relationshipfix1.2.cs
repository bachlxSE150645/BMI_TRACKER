using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BussinessObject.Migrations
{
    /// <inheritdoc />
    public partial class relationshipfix12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_foods_categories_categorysCategoryId",
                table: "foods");

            migrationBuilder.DropForeignKey(
                name: "FK_ingredients_categories_categorysCategoryId",
                table: "ingredients");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "menus");

            migrationBuilder.DropColumn(
                name: "categoryName",
                table: "ingredients");

            migrationBuilder.RenameColumn(
                name: "categorysCategoryId",
                table: "ingredients",
                newName: "categoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ingredients_categorysCategoryId",
                table: "ingredients",
                newName: "IX_ingredients_categoryId");

            migrationBuilder.RenameColumn(
                name: "categorysCategoryId",
                table: "foods",
                newName: "categoryId");

            migrationBuilder.RenameIndex(
                name: "IX_foods_categorysCategoryId",
                table: "foods",
                newName: "IX_foods_categoryId");

            migrationBuilder.AddColumn<Guid>(
                name: "category",
                table: "menus",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_foods_categories_categoryId",
                table: "foods",
                column: "categoryId",
                principalTable: "categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ingredients_categories_categoryId",
                table: "ingredients",
                column: "categoryId",
                principalTable: "categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_foods_categories_categoryId",
                table: "foods");

            migrationBuilder.DropForeignKey(
                name: "FK_ingredients_categories_categoryId",
                table: "ingredients");

            migrationBuilder.DropColumn(
                name: "category",
                table: "menus");

            migrationBuilder.RenameColumn(
                name: "categoryId",
                table: "ingredients",
                newName: "categorysCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ingredients_categoryId",
                table: "ingredients",
                newName: "IX_ingredients_categorysCategoryId");

            migrationBuilder.RenameColumn(
                name: "categoryId",
                table: "foods",
                newName: "categorysCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_foods_categoryId",
                table: "foods",
                newName: "IX_foods_categorysCategoryId");

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "menus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "categoryName",
                table: "ingredients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_foods_categories_categorysCategoryId",
                table: "foods",
                column: "categorysCategoryId",
                principalTable: "categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ingredients_categories_categorysCategoryId",
                table: "ingredients",
                column: "categorysCategoryId",
                principalTable: "categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
