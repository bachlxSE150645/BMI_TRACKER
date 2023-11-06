using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BussinessObject.Migrations
{
    /// <inheritdoc />
    public partial class relationshipfix13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_services_serviceTypes_serviceTypesServiceTypeId",
                table: "services");

            migrationBuilder.DropForeignKey(
                name: "FK_serviceTypes_users_usersuserId",
                table: "serviceTypes");

            migrationBuilder.RenameColumn(
                name: "usersuserId",
                table: "serviceTypes",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_serviceTypes_usersuserId",
                table: "serviceTypes",
                newName: "IX_serviceTypes_userId");

            migrationBuilder.RenameColumn(
                name: "serviceTypesServiceTypeId",
                table: "services",
                newName: "serviceTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_services_serviceTypesServiceTypeId",
                table: "services",
                newName: "IX_services_serviceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_services_serviceTypes_serviceTypeId",
                table: "services",
                column: "serviceTypeId",
                principalTable: "serviceTypes",
                principalColumn: "ServiceTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_serviceTypes_users_userId",
                table: "serviceTypes",
                column: "userId",
                principalTable: "users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_services_serviceTypes_serviceTypeId",
                table: "services");

            migrationBuilder.DropForeignKey(
                name: "FK_serviceTypes_users_userId",
                table: "serviceTypes");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "serviceTypes",
                newName: "usersuserId");

            migrationBuilder.RenameIndex(
                name: "IX_serviceTypes_userId",
                table: "serviceTypes",
                newName: "IX_serviceTypes_usersuserId");

            migrationBuilder.RenameColumn(
                name: "serviceTypeId",
                table: "services",
                newName: "serviceTypesServiceTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_services_serviceTypeId",
                table: "services",
                newName: "IX_services_serviceTypesServiceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_services_serviceTypes_serviceTypesServiceTypeId",
                table: "services",
                column: "serviceTypesServiceTypeId",
                principalTable: "serviceTypes",
                principalColumn: "ServiceTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_serviceTypes_users_usersuserId",
                table: "serviceTypes",
                column: "usersuserId",
                principalTable: "users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
