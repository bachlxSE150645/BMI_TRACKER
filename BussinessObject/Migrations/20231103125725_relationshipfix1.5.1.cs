using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BussinessObject.Migrations
{
    /// <inheritdoc />
    public partial class relationshipfix151 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_feedbacks_feedbacksfeedbackId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_feedbacksfeedbackId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "feedbacksfeedbackId",
                table: "users");

            migrationBuilder.AddColumn<Guid>(
                name: "usersuserId",
                table: "feedbacks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_feedbacks_usersuserId",
                table: "feedbacks",
                column: "usersuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_feedbacks_users_usersuserId",
                table: "feedbacks",
                column: "usersuserId",
                principalTable: "users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_feedbacks_users_usersuserId",
                table: "feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_feedbacks_usersuserId",
                table: "feedbacks");

            migrationBuilder.DropColumn(
                name: "usersuserId",
                table: "feedbacks");

            migrationBuilder.AddColumn<Guid>(
                name: "feedbacksfeedbackId",
                table: "users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_users_feedbacksfeedbackId",
                table: "users",
                column: "feedbacksfeedbackId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_feedbacks_feedbacksfeedbackId",
                table: "users",
                column: "feedbacksfeedbackId",
                principalTable: "feedbacks",
                principalColumn: "feedbackId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
