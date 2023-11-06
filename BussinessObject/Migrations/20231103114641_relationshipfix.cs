using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BussinessObject.Migrations
{
    /// <inheritdoc />
    public partial class relationshipfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_foods_categories_categorysCategoryId",
                table: "foods");

            migrationBuilder.DropIndex(
                name: "IX_foods_categorysCategoryId",
                table: "foods");

            migrationBuilder.DropColumn(
                name: "userInfoId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "categorysCategoryId",
                table: "foods");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "foods",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_foods_CategoryId",
                table: "foods",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_foods_categories_CategoryId",
                table: "foods",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_foods_categories_CategoryId",
                table: "foods");

            migrationBuilder.DropIndex(
                name: "IX_foods_CategoryId",
                table: "foods");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "foods");

            migrationBuilder.AddColumn<Guid>(
                name: "userInfoId",
                table: "users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "categorysCategoryId",
                table: "foods",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_foods_categorysCategoryId",
                table: "foods",
                column: "categorysCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_foods_categories_categorysCategoryId",
                table: "foods",
                column: "categorysCategoryId",
                principalTable: "categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
