﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodoListApi.Data;

#nullable disable

namespace TodoListApi.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230815121309_AddUserIdInTodosTable")]
    partial class AddUserIdInTodosTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TodoListApi.Models.Todo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Todos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 8, 15, 14, 13, 9, 395, DateTimeKind.Local).AddTicks(9134),
                            Description = "Make yourself a balanced breakfast including proteins, carbohydrates, and vitamins. For instance, an omelette with vegetables and a slice of bread.",
                            Status = 1,
                            Title = "Prepare Breakfast",
                            UserId = 99
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2023, 8, 7, 14, 13, 9, 395, DateTimeKind.Local).AddTicks(9201),
                            Description = "Dedicate some time to physical exercises. It will help awaken your body, improve your mood, and get you ready for the day.",
                            Status = 2,
                            Title = "Morning Workout",
                            UserId = 99
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2023, 6, 15, 14, 13, 9, 395, DateTimeKind.Local).AddTicks(9207),
                            Description = "Check your email and respond to important messages. This will help you stay connected with colleagues, friends, and partners",
                            Status = 3,
                            Title = "Respond to Emails",
                            UserId = 99
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2023, 8, 15, 12, 53, 9, 395, DateTimeKind.Local).AddTicks(9213),
                            Description = "Create a task list for the day and prioritize them. This will help you organize your work and achieve your goals.",
                            Status = 1,
                            Title = "Plan Your Work Day",
                            UserId = 93
                        },
                        new
                        {
                            Id = 5,
                            CreatedDate = new DateTime(2023, 8, 13, 14, 13, 9, 395, DateTimeKind.Local).AddTicks(9216),
                            Description = "Engage in your main tasks according to the list. Avoid distractions and try to focus on one task at a time.",
                            Status = 1,
                            Title = "Productive Work Time",
                            UserId = 99
                        },
                        new
                        {
                            Id = 6,
                            CreatedDate = new DateTime(2023, 8, 12, 14, 13, 9, 395, DateTimeKind.Local).AddTicks(9218),
                            Description = "Take a break and have lunch. Consider healthy eating, including vegetables, proteins, and healthy fats.",
                            Status = 1,
                            Title = "Lunch Break",
                            UserId = 9
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
