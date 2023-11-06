using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BussinessObject.Migrations
{
    /// <inheritdoc />
    public partial class relationshipfix154 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_serviceTypes_users_userId",
                table: "serviceTypes");

            migrationBuilder.DropIndex(
                name: "IX_serviceTypes_userId",
                table: "serviceTypes");

            migrationBuilder.DropIndex(
                name: "IX_orders_paymentId",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "serviceTypes");

            migrationBuilder.DropColumn(
                name: "orderId",
                table: "Payments");

            migrationBuilder.AddColumn<Guid>(
                name: "userBodyMaxsuserInfoId",
                table: "schedules",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_schedules_userBodyMaxsuserInfoId",
                table: "schedules",
                column: "userBodyMaxsuserInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_paymentId",
                table: "orders",
                column: "paymentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_schedules_userBodyMaxes_userBodyMaxsuserInfoId",
                table: "schedules",
                column: "userBodyMaxsuserInfoId",
                principalTable: "userBodyMaxes",
                principalColumn: "userInfoId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_schedules_userBodyMaxes_userBodyMaxsuserInfoId",
                table: "schedules");

            migrationBuilder.DropIndex(
                name: "IX_schedules_userBodyMaxsuserInfoId",
                table: "schedules");

            migrationBuilder.DropIndex(
                name: "IX_orders_paymentId",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "userBodyMaxsuserInfoId",
                table: "schedules");

            migrationBuilder.AddColumn<Guid>(
                name: "userId",
                table: "serviceTypes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "orderId",
                table: "Payments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_serviceTypes_userId",
                table: "serviceTypes",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_paymentId",
                table: "orders",
                column: "paymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_serviceTypes_users_userId",
                table: "serviceTypes",
                column: "userId",
                principalTable: "users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
