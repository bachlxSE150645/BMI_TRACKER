using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BussinessObject.Migrations
{
    /// <inheritdoc />
    public partial class fixCom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Complements_blogId",
                table: "Complements");

            migrationBuilder.DropIndex(
                name: "IX_Complements_serviceId",
                table: "Complements");

            migrationBuilder.DropIndex(
                name: "IX_Complements_userId",
                table: "Complements");

            migrationBuilder.DropColumn(
                name: "ratingId",
                table: "services");

            migrationBuilder.DropColumn(
                name: "ratingId",
                table: "blogs");

            migrationBuilder.CreateIndex(
                name: "IX_Complements_blogId",
                table: "Complements",
                column: "blogId");

            migrationBuilder.CreateIndex(
                name: "IX_Complements_serviceId",
                table: "Complements",
                column: "serviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Complements_userId",
                table: "Complements",
                column: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Complements_blogId",
                table: "Complements");

            migrationBuilder.DropIndex(
                name: "IX_Complements_serviceId",
                table: "Complements");

            migrationBuilder.DropIndex(
                name: "IX_Complements_userId",
                table: "Complements");

            migrationBuilder.AddColumn<string>(
                name: "ratingId",
                table: "services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ratingId",
                table: "blogs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Complements_blogId",
                table: "Complements",
                column: "blogId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Complements_serviceId",
                table: "Complements",
                column: "serviceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Complements_userId",
                table: "Complements",
                column: "userId",
                unique: true);
        }
    }
}
