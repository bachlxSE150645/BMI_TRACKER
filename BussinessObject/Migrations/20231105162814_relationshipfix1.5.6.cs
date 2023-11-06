using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BussinessObject.Migrations
{
    /// <inheritdoc />
    public partial class relationshipfix156 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "type",
                table: "feedbacks");

            migrationBuilder.AddColumn<Guid>(
                name: "userBodyMaxId",
                table: "orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_orders_userBodyMaxId",
                table: "orders",
                column: "userBodyMaxId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_userBodyMaxes_userBodyMaxId",
                table: "orders",
                column: "userBodyMaxId",
                principalTable: "userBodyMaxes",
                principalColumn: "userInfoId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_userBodyMaxes_userBodyMaxId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_userBodyMaxId",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "userBodyMaxId",
                table: "orders");

            migrationBuilder.AddColumn<int>(
                name: "type",
                table: "feedbacks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
