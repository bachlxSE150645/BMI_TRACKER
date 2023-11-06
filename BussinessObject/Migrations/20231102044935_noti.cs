using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BussinessObject.Migrations
{
    /// <inheritdoc />
    public partial class noti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "notificationId",
                table: "users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "notifications",
                columns: table => new
                {
                    notificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    notificationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notifications", x => x.notificationId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_notificationId",
                table: "users",
                column: "notificationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_users_notifications_notificationId",
                table: "users",
                column: "notificationId",
                principalTable: "notifications",
                principalColumn: "notificationId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_notifications_notificationId",
                table: "users");

            migrationBuilder.DropTable(
                name: "notifications");

            migrationBuilder.DropIndex(
                name: "IX_users_notificationId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "notificationId",
                table: "users");
        }
    }
}
