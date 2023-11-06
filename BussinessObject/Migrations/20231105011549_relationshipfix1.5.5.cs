using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BussinessObject.Migrations
{
    /// <inheritdoc />
    public partial class relationshipfix155 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_schedules_users_userId",
                table: "schedules");

            migrationBuilder.DropIndex(
                name: "IX_schedules_userId",
                table: "schedules");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_schedules_userId",
                table: "schedules",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_schedules_users_userId",
                table: "schedules",
                column: "userId",
                principalTable: "users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
