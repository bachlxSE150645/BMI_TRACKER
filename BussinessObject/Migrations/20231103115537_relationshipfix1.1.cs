using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BussinessObject.Migrations
{
    /// <inheritdoc />
    public partial class relationshipfix11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_foods_categories_CategoryId",
                table: "foods");

            migrationBuilder.DropForeignKey(
                name: "FK_users_roles_rolesroleId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_foods_CategoryId",
                table: "foods");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "foods");

            migrationBuilder.DropColumn(
                name: "categoryName",
                table: "foods");

            migrationBuilder.RenameColumn(
                name: "rolesroleId",
                table: "users",
                newName: "roleId");

            migrationBuilder.RenameIndex(
                name: "IX_users_rolesroleId",
                table: "users",
                newName: "IX_users_roleId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_users_roles_roleId",
                table: "users",
                column: "roleId",
                principalTable: "roles",
                principalColumn: "roleId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_foods_categories_categorysCategoryId",
                table: "foods");

            migrationBuilder.DropForeignKey(
                name: "FK_users_roles_roleId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_foods_categorysCategoryId",
                table: "foods");

            migrationBuilder.DropColumn(
                name: "categorysCategoryId",
                table: "foods");

            migrationBuilder.RenameColumn(
                name: "roleId",
                table: "users",
                newName: "rolesroleId");

            migrationBuilder.RenameIndex(
                name: "IX_users_roleId",
                table: "users",
                newName: "IX_users_rolesroleId");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "foods",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "categoryName",
                table: "foods",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddForeignKey(
                name: "FK_users_roles_rolesroleId",
                table: "users",
                column: "rolesroleId",
                principalTable: "roles",
                principalColumn: "roleId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
