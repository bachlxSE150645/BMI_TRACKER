using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BussinessObject.Migrations
{
    /// <inheritdoc />
    public partial class relationshipfix152 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_feedbacks_users_usersuserId",
                table: "feedbacks");

            migrationBuilder.RenameColumn(
                name: "usersuserId",
                table: "feedbacks",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_feedbacks_usersuserId",
                table: "feedbacks",
                newName: "IX_feedbacks_userId");

            migrationBuilder.AddForeignKey(
                name: "FK_feedbacks_users_userId",
                table: "feedbacks",
                column: "userId",
                principalTable: "users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_feedbacks_users_userId",
                table: "feedbacks");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "feedbacks",
                newName: "usersuserId");

            migrationBuilder.RenameIndex(
                name: "IX_feedbacks_userId",
                table: "feedbacks",
                newName: "IX_feedbacks_usersuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_feedbacks_users_usersuserId",
                table: "feedbacks",
                column: "usersuserId",
                principalTable: "users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
