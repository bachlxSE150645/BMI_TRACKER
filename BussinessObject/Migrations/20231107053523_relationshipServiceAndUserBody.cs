using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BussinessObject.Migrations
{
    /// <inheritdoc />
    public partial class relationshipServiceAndUserBody : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_userBodyMaxes_serviceId",
                table: "userBodyMaxes");

            migrationBuilder.DropColumn(
                name: "userInfoId",
                table: "services");

            migrationBuilder.CreateIndex(
                name: "IX_userBodyMaxes_serviceId",
                table: "userBodyMaxes",
                column: "serviceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_userBodyMaxes_serviceId",
                table: "userBodyMaxes");

            migrationBuilder.AddColumn<Guid>(
                name: "userInfoId",
                table: "services",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_userBodyMaxes_serviceId",
                table: "userBodyMaxes",
                column: "serviceId",
                unique: true);
        }
    }
}
