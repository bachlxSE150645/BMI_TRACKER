using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BussinessObject.Migrations
{
    /// <inheritdoc />
    public partial class ServiceTypeuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "usersuserId",
                table: "serviceTypes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_serviceTypes_usersuserId",
                table: "serviceTypes",
                column: "usersuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_serviceTypes_users_usersuserId",
                table: "serviceTypes",
                column: "usersuserId",
                principalTable: "users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_serviceTypes_users_usersuserId",
                table: "serviceTypes");

            migrationBuilder.DropIndex(
                name: "IX_serviceTypes_usersuserId",
                table: "serviceTypes");

            migrationBuilder.DropColumn(
                name: "usersuserId",
                table: "serviceTypes");
        }
    }
}
