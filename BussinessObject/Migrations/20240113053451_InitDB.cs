using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BussinessObject.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "messages",
                columns: table => new
                {
                    messageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messages", x => x.messageId);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    roleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    roleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.roleId);
                });

            migrationBuilder.CreateTable(
                name: "foods",
                columns: table => new
                {
                    foodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    foodName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    foodTag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    foodNutrition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    foodNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    foodDesciption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    foodPhoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    foodtimeProcess = table.Column<int>(type: "int", nullable: false),
                    foodCalorios = table.Column<int>(type: "int", nullable: false),
                    foodProcessingVideo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    categoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_foods", x => x.foodId);
                    table.ForeignKey(
                        name: "FK_foods_categories_categoryId",
                        column: x => x.categoryId,
                        principalTable: "categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ingredients",
                columns: table => new
                {
                    ingredientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ingredientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ingredientPhoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    categoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingredients", x => x.ingredientId);
                    table.ForeignKey(
                        name: "FK_ingredients_categories_categoryId",
                        column: x => x.categoryId,
                        principalTable: "categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    certificateId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    certificateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    roleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.userId);
                    table.ForeignKey(
                        name: "FK_users_roles_roleId",
                        column: x => x.roleId,
                        principalTable: "roles",
                        principalColumn: "roleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "recipes",
                columns: table => new
                {
                    ingredientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    foodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipes", x => new { x.ingredientId, x.foodId });
                    table.ForeignKey(
                        name: "FK_recipes_foods_foodId",
                        column: x => x.foodId,
                        principalTable: "foods",
                        principalColumn: "foodId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_recipes_ingredients_ingredientId",
                        column: x => x.ingredientId,
                        principalTable: "ingredients",
                        principalColumn: "ingredientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "blogs",
                columns: table => new
                {
                    bolgId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    blogName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    blogContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    blogPhoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blogs", x => x.bolgId);
                    table.ForeignKey(
                        name: "FK_blogs_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "chatSection",
                columns: table => new
                {
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    messageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chatSection", x => new { x.userId, x.messageId });
                    table.ForeignKey(
                        name: "FK_chatSection_messages_messageId",
                        column: x => x.messageId,
                        principalTable: "messages",
                        principalColumn: "messageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_chatSection_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "favoriteFoods",
                columns: table => new
                {
                    foodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_favoriteFoods", x => new { x.foodId, x.userId });
                    table.ForeignKey(
                        name: "FK_favoriteFoods_foods_foodId",
                        column: x => x.foodId,
                        principalTable: "foods",
                        principalColumn: "foodId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_favoriteFoods_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "feedbacks",
                columns: table => new
                {
                    feedbackId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedbacks", x => x.feedbackId);
                    table.ForeignKey(
                        name: "FK_feedbacks_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "menus",
                columns: table => new
                {
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    menuName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    menuDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    menuType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    menuPhoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    categoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menus", x => x.MenuId);
                    table.ForeignKey(
                        name: "FK_menus_categories_categoryId",
                        column: x => x.categoryId,
                        principalTable: "categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_menus_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "notifications",
                columns: table => new
                {
                    notificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    notificationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notifications", x => x.notificationId);
                    table.ForeignKey(
                        name: "FK_notifications_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "services",
                columns: table => new
                {
                    serviceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nameService = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descriptionService = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_services", x => x.serviceId);
                    table.ForeignKey(
                        name: "FK_services_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "userBodyMaxes",
                columns: table => new
                {
                    userInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    heght = table.Column<float>(type: "real", nullable: false),
                    weight = table.Column<float>(type: "real", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    BMIPerson = table.Column<float>(type: "real", nullable: false),
                    BMR = table.Column<float>(type: "real", nullable: false),
                    TDEE = table.Column<float>(type: "real", nullable: false),
                    sex = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateInput = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userBodyMaxes", x => x.userInfoId);
                    table.ForeignKey(
                        name: "FK_userBodyMaxes_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "meals",
                columns: table => new
                {
                    menuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    foodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_meals", x => new { x.menuId, x.foodId });
                    table.ForeignKey(
                        name: "FK_meals_foods_foodId",
                        column: x => x.foodId,
                        principalTable: "foods",
                        principalColumn: "foodId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_meals_menus_menuId",
                        column: x => x.menuId,
                        principalTable: "menus",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "trackForms",
                columns: table => new
                {
                    trackFormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    serviceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    trackFormName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    trackeFormDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trackForms", x => new { x.trackFormId, x.serviceId, x.userId });
                    table.ForeignKey(
                        name: "FK_trackForms_services_serviceId",
                        column: x => x.serviceId,
                        principalTable: "services",
                        principalColumn: "serviceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trackForms_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    orderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    serviceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    orderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    orderDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    orderStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    orderPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    orderDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => new { x.userInfoId, x.serviceId, x.orderId });
                    table.ForeignKey(
                        name: "FK_orders_services_serviceId",
                        column: x => x.serviceId,
                        principalTable: "services",
                        principalColumn: "serviceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_orders_userBodyMaxes_userInfoId",
                        column: x => x.userInfoId,
                        principalTable: "userBodyMaxes",
                        principalColumn: "userInfoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "schedules",
                columns: table => new
                {
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schedules", x => new { x.MenuId, x.userInfoId });
                    table.ForeignKey(
                        name: "FK_schedules_menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "menus",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_schedules_userBodyMaxes_userInfoId",
                        column: x => x.userInfoId,
                        principalTable: "userBodyMaxes",
                        principalColumn: "userInfoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_blogs_userId",
                table: "blogs",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_chatSection_messageId",
                table: "chatSection",
                column: "messageId");

            migrationBuilder.CreateIndex(
                name: "IX_favoriteFoods_userId",
                table: "favoriteFoods",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_feedbacks_userId",
                table: "feedbacks",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_foods_categoryId",
                table: "foods",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ingredients_categoryId",
                table: "ingredients",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_meals_foodId",
                table: "meals",
                column: "foodId");

            migrationBuilder.CreateIndex(
                name: "IX_menus_categoryId",
                table: "menus",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_menus_userId",
                table: "menus",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_notifications_userId",
                table: "notifications",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_serviceId",
                table: "orders",
                column: "serviceId");

            migrationBuilder.CreateIndex(
                name: "IX_recipes_foodId",
                table: "recipes",
                column: "foodId");

            migrationBuilder.CreateIndex(
                name: "IX_schedules_userInfoId",
                table: "schedules",
                column: "userInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_services_userId",
                table: "services",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_trackForms_serviceId",
                table: "trackForms",
                column: "serviceId");

            migrationBuilder.CreateIndex(
                name: "IX_trackForms_userId",
                table: "trackForms",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_userBodyMaxes_userId",
                table: "userBodyMaxes",
                column: "userId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_roleId",
                table: "users",
                column: "roleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "blogs");

            migrationBuilder.DropTable(
                name: "chatSection");

            migrationBuilder.DropTable(
                name: "favoriteFoods");

            migrationBuilder.DropTable(
                name: "feedbacks");

            migrationBuilder.DropTable(
                name: "meals");

            migrationBuilder.DropTable(
                name: "notifications");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "recipes");

            migrationBuilder.DropTable(
                name: "schedules");

            migrationBuilder.DropTable(
                name: "trackForms");

            migrationBuilder.DropTable(
                name: "messages");

            migrationBuilder.DropTable(
                name: "foods");

            migrationBuilder.DropTable(
                name: "ingredients");

            migrationBuilder.DropTable(
                name: "menus");

            migrationBuilder.DropTable(
                name: "userBodyMaxes");

            migrationBuilder.DropTable(
                name: "services");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
