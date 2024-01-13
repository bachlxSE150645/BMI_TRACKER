﻿// <auto-generated />
using System;
using BussinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BussinessObject.Migrations
{
    [DbContext(typeof(MyDbContext))]
<<<<<<<< HEAD:BussinessObject/Migrations/20240113053451_InitDB.Designer.cs
    [Migration("20240113053451_InitDB")]
    partial class InitDB
========
    [Migration("20240109062115_InitDB2.5")]
    partial class InitDB25
>>>>>>>> 0dfa92a9280286804d5ac8d3500958d657ab7d94:BussinessObject/Migrations/20240109062115_InitDB2.5.Designer.cs
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BussinessObject.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("BussinessObject.Meal", b =>
                {
                    b.Property<Guid>("menuId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("foodId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("menuId", "foodId");

                    b.HasIndex("foodId");

                    b.ToTable("meals");
                });

            modelBuilder.Entity("BussinessObject.Menu", b =>
                {
                    b.Property<Guid>("MenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("categoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("menuDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("menuName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("menuPhoto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("menuType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

<<<<<<<< HEAD:BussinessObject/Migrations/20240113053451_InitDB.Designer.cs
                    b.Property<Guid>("userId")
                        .HasColumnType("uniqueidentifier");

========
>>>>>>>> 0dfa92a9280286804d5ac8d3500958d657ab7d94:BussinessObject/Migrations/20240109062115_InitDB2.5.Designer.cs
                    b.HasKey("MenuId");

                    b.HasIndex("categoryId");

                    b.HasIndex("userId");

                    b.ToTable("menus");
                });

            modelBuilder.Entity("BussinessObject.Schedule", b =>
                {
                    b.Property<Guid>("MenuId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("userInfoId")
                        .HasColumnType("uniqueidentifier");

<<<<<<<< HEAD:BussinessObject/Migrations/20240113053451_InitDB.Designer.cs
========
                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

>>>>>>>> 0dfa92a9280286804d5ac8d3500958d657ab7d94:BussinessObject/Migrations/20240109062115_InitDB2.5.Designer.cs
                    b.HasKey("MenuId", "userInfoId");

                    b.HasIndex("userInfoId");

                    b.ToTable("schedules");
                });

            modelBuilder.Entity("BussinessObject.Service", b =>
                {
                    b.Property<Guid>("serviceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("descriptionService")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nameService")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("userId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("serviceId");

                    b.HasIndex("userId");

                    b.ToTable("services");
                });

            modelBuilder.Entity("BussinessObject.blog", b =>
                {
                    b.Property<Guid>("bolgId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("blogContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("blogName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("blogPhoto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("userId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("bolgId");

                    b.HasIndex("userId");

                    b.ToTable("blogs");
                });

            modelBuilder.Entity("BussinessObject.chatSection", b =>
                {
                    b.Property<Guid>("userId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("messageId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("userId", "messageId");

                    b.HasIndex("messageId");

                    b.ToTable("chatSection");
                });

            modelBuilder.Entity("BussinessObject.favoriteFood", b =>
                {
                    b.Property<Guid>("foodId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("userId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("foodId", "userId");

                    b.HasIndex("userId");

                    b.ToTable("favoriteFoods");
                });

            modelBuilder.Entity("BussinessObject.feedback", b =>
                {
                    b.Property<Guid>("feedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("userId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("feedbackId");

                    b.HasIndex("userId");

                    b.ToTable("feedbacks");
                });

            modelBuilder.Entity("BussinessObject.food", b =>
                {
                    b.Property<Guid>("foodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("categoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("foodCalorios")
                        .HasColumnType("int");

                    b.Property<string>("foodDesciption")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("foodName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("foodNotes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("foodNutrition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("foodPhoto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("foodProcessingVideo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("foodTag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("foodtimeProcess")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("foodId");

                    b.HasIndex("categoryId");

                    b.ToTable("foods");
                });

            modelBuilder.Entity("BussinessObject.ingredient", b =>
                {
                    b.Property<Guid>("ingredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("categoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ingredientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ingredientPhoto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ingredientId");

                    b.HasIndex("categoryId");

                    b.ToTable("ingredients");
                });

            modelBuilder.Entity("BussinessObject.message", b =>
                {
                    b.Property<Guid>("messageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("file")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("messageId");

                    b.ToTable("messages");
                });

            modelBuilder.Entity("BussinessObject.notification", b =>
                {
                    b.Property<Guid>("notificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("notificationName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("type")
                        .HasColumnType("int");

                    b.Property<Guid>("userId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("notificationId");

                    b.HasIndex("userId");

                    b.ToTable("notifications");
                });

            modelBuilder.Entity("BussinessObject.order", b =>
                {
                    b.Property<Guid>("userInfoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("serviceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("orderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("orderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("orderDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("orderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("orderPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("orderStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userInfoId", "serviceId", "orderId");

                    b.HasIndex("serviceId");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("BussinessObject.recipe", b =>
                {
                    b.Property<Guid>("ingredientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("foodId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ingredientId", "foodId");

                    b.HasIndex("foodId");

                    b.ToTable("recipes");
                });

            modelBuilder.Entity("BussinessObject.role", b =>
                {
                    b.Property<Guid>("roleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("roleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("roleId");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("BussinessObject.trackForm", b =>
                {
                    b.Property<Guid>("trackFormId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("serviceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("userId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("trackFormName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("trackeFormDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("trackFormId", "serviceId", "userId");

                    b.HasIndex("serviceId");

                    b.HasIndex("userId");

                    b.ToTable("trackForms");
                });

            modelBuilder.Entity("BussinessObject.user", b =>
                {
                    b.Property<Guid>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("certificateId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("certificateName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("roleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userId");

                    b.HasIndex("roleId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("BussinessObject.userBodyMax", b =>
                {
                    b.Property<Guid>("userInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("BMIPerson")
                        .HasColumnType("real");

                    b.Property<float>("BMR")
                        .HasColumnType("real");

                    b.Property<float>("TDEE")
                        .HasColumnType("real");

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<DateTime>("dateInput")
                        .HasColumnType("datetime2");

                    b.Property<float>("heght")
                        .HasColumnType("real");

                    b.Property<int>("sex")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("userId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("weight")
                        .HasColumnType("real");

                    b.HasKey("userInfoId");

                    b.HasIndex("userId")
                        .IsUnique();

                    b.ToTable("userBodyMaxes");
                });

            modelBuilder.Entity("BussinessObject.Meal", b =>
                {
                    b.HasOne("BussinessObject.food", "foods")
                        .WithMany("meals")
                        .HasForeignKey("foodId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BussinessObject.Menu", "Menus")
                        .WithMany("meals")
                        .HasForeignKey("menuId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Menus");

                    b.Navigation("foods");
                });

            modelBuilder.Entity("BussinessObject.Menu", b =>
                {
                    b.HasOne("BussinessObject.Category", "categorys")
                        .WithMany("menus")
                        .HasForeignKey("categoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BussinessObject.user", "users")
                        .WithMany("menus")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("categorys");

                    b.Navigation("users");
                });

            modelBuilder.Entity("BussinessObject.Schedule", b =>
                {
                    b.HasOne("BussinessObject.Menu", "menus")
                        .WithMany("schedules")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BussinessObject.userBodyMax", "userBodyMaxs")
                        .WithMany("schedules")
                        .HasForeignKey("userInfoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("menus");

                    b.Navigation("userBodyMaxs");
                });

            modelBuilder.Entity("BussinessObject.Service", b =>
                {
                    b.HasOne("BussinessObject.user", "users")
                        .WithMany("services")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("users");
                });

            modelBuilder.Entity("BussinessObject.blog", b =>
                {
                    b.HasOne("BussinessObject.user", "users")
                        .WithMany("blogs")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("users");
                });

            modelBuilder.Entity("BussinessObject.chatSection", b =>
                {
                    b.HasOne("BussinessObject.message", "messages")
                        .WithMany("chatSections")
                        .HasForeignKey("messageId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BussinessObject.user", "users")
                        .WithMany("chatSections")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("messages");

                    b.Navigation("users");
                });

            modelBuilder.Entity("BussinessObject.favoriteFood", b =>
                {
                    b.HasOne("BussinessObject.food", "foods")
                        .WithMany("favoriteFoods")
                        .HasForeignKey("foodId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BussinessObject.user", "users")
                        .WithMany("favoriteFoods")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("foods");

                    b.Navigation("users");
                });

            modelBuilder.Entity("BussinessObject.feedback", b =>
                {
                    b.HasOne("BussinessObject.user", "users")
                        .WithMany("feedbacks")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("users");
                });

            modelBuilder.Entity("BussinessObject.food", b =>
                {
                    b.HasOne("BussinessObject.Category", "categorys")
                        .WithMany("foods")
                        .HasForeignKey("categoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("categorys");
                });

            modelBuilder.Entity("BussinessObject.ingredient", b =>
                {
                    b.HasOne("BussinessObject.Category", "categorys")
                        .WithMany("ingredients")
                        .HasForeignKey("categoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("categorys");
                });

            modelBuilder.Entity("BussinessObject.notification", b =>
                {
                    b.HasOne("BussinessObject.user", "users")
                        .WithMany("notifications")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("users");
                });

            modelBuilder.Entity("BussinessObject.order", b =>
                {
                    b.HasOne("BussinessObject.Service", "services")
                        .WithMany("orders")
                        .HasForeignKey("serviceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BussinessObject.userBodyMax", "userBodyMaxs")
                        .WithMany("orders")
                        .HasForeignKey("userInfoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("services");

                    b.Navigation("userBodyMaxs");
                });

            modelBuilder.Entity("BussinessObject.recipe", b =>
                {
                    b.HasOne("BussinessObject.food", "foods")
                        .WithMany("recipes")
                        .HasForeignKey("foodId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BussinessObject.ingredient", "ingredients")
                        .WithMany("recipes")
                        .HasForeignKey("ingredientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("foods");

                    b.Navigation("ingredients");
                });

            modelBuilder.Entity("BussinessObject.trackForm", b =>
                {
                    b.HasOne("BussinessObject.Service", "services")
                        .WithMany("trackForms")
                        .HasForeignKey("serviceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BussinessObject.user", "users")
                        .WithMany("trackForms")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("services");

                    b.Navigation("users");
                });

            modelBuilder.Entity("BussinessObject.user", b =>
                {
                    b.HasOne("BussinessObject.role", "roles")
                        .WithMany("users")
                        .HasForeignKey("roleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("roles");
                });

            modelBuilder.Entity("BussinessObject.userBodyMax", b =>
                {
                    b.HasOne("BussinessObject.user", "users")
                        .WithOne("userBodyMaxs")
                        .HasForeignKey("BussinessObject.userBodyMax", "userId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("users");
                });

            modelBuilder.Entity("BussinessObject.Category", b =>
                {
                    b.Navigation("foods");

                    b.Navigation("ingredients");

                    b.Navigation("menus");
                });

            modelBuilder.Entity("BussinessObject.Menu", b =>
                {
                    b.Navigation("meals");

                    b.Navigation("schedules");
                });

            modelBuilder.Entity("BussinessObject.Service", b =>
                {
                    b.Navigation("orders");

                    b.Navigation("trackForms");
                });

            modelBuilder.Entity("BussinessObject.food", b =>
                {
                    b.Navigation("favoriteFoods");

                    b.Navigation("meals");

                    b.Navigation("recipes");
                });

            modelBuilder.Entity("BussinessObject.ingredient", b =>
                {
                    b.Navigation("recipes");
                });

            modelBuilder.Entity("BussinessObject.message", b =>
                {
                    b.Navigation("chatSections");
                });

            modelBuilder.Entity("BussinessObject.role", b =>
                {
                    b.Navigation("users");
                });

            modelBuilder.Entity("BussinessObject.user", b =>
                {
                    b.Navigation("blogs");

                    b.Navigation("chatSections");

                    b.Navigation("favoriteFoods");

                    b.Navigation("feedbacks");

<<<<<<<< HEAD:BussinessObject/Migrations/20240113053451_InitDB.Designer.cs
                    b.Navigation("menus");

========
>>>>>>>> 0dfa92a9280286804d5ac8d3500958d657ab7d94:BussinessObject/Migrations/20240109062115_InitDB2.5.Designer.cs
                    b.Navigation("notifications");

                    b.Navigation("services");

                    b.Navigation("trackForms");

                    b.Navigation("userBodyMaxs")
                        .IsRequired();
                });

            modelBuilder.Entity("BussinessObject.userBodyMax", b =>
                {
                    b.Navigation("orders");

                    b.Navigation("schedules");
                });
#pragma warning restore 612, 618
        }
    }
}
