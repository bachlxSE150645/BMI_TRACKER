using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BussinessObject.Migrations
{
    /// <inheritdoc />
    public partial class userMaxBody : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userBodyMaxes_users_userId",
                table: "userBodyMaxes");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "userBodyMaxes",
                newName: "users");

            migrationBuilder.RenameIndex(
                name: "IX_userBodyMaxes_userId",
                table: "userBodyMaxes",
                newName: "IX_userBodyMaxes_users");

            migrationBuilder.AddColumn<float>(
                name: "BMIPerson",
                table: "userBodyMaxes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddForeignKey(
                name: "FK_userBodyMaxes_users_users",
                table: "userBodyMaxes",
                column: "users",
                principalTable: "users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userBodyMaxes_users_users",
                table: "userBodyMaxes");

            migrationBuilder.DropColumn(
                name: "BMIPerson",
                table: "userBodyMaxes");

            migrationBuilder.RenameColumn(
                name: "users",
                table: "userBodyMaxes",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_userBodyMaxes_users",
                table: "userBodyMaxes",
                newName: "IX_userBodyMaxes_userId");

            migrationBuilder.AddForeignKey(
                name: "FK_userBodyMaxes_users_userId",
                table: "userBodyMaxes",
                column: "userId",
                principalTable: "users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
