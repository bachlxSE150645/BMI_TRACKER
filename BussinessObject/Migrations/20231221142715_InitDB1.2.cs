using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BussinessObject.Migrations
{
    /// <inheritdoc />
    public partial class InitDB12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_trackForms",
                table: "trackForms");

            migrationBuilder.DropColumn(
                name: "isTracked",
                table: "trackForms");

            migrationBuilder.AddColumn<Guid>(
                name: "serviceId",
                table: "trackForms",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_trackForms",
                table: "trackForms",
                columns: new[] { "trackFormId", "serviceId", "userId" });

            migrationBuilder.CreateIndex(
                name: "IX_trackForms_serviceId",
                table: "trackForms",
                column: "serviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_trackForms_services_serviceId",
                table: "trackForms",
                column: "serviceId",
                principalTable: "services",
                principalColumn: "serviceId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_trackForms_services_serviceId",
                table: "trackForms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_trackForms",
                table: "trackForms");

            migrationBuilder.DropIndex(
                name: "IX_trackForms_serviceId",
                table: "trackForms");

            migrationBuilder.DropColumn(
                name: "serviceId",
                table: "trackForms");

            migrationBuilder.AddColumn<bool>(
                name: "isTracked",
                table: "trackForms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_trackForms",
                table: "trackForms",
                column: "trackFormId");
        }
    }
}
