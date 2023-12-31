﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodoList.Persistence.Data;

#nullable disable

namespace TodoList.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230909164548_Check")]
    partial class Check
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TodoList.Models.Todo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
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
                            CreatedAt = new DateTime(2023, 9, 9, 18, 45, 48, 221, DateTimeKind.Local).AddTicks(8877),
                            Description = "Make yourself a balanced breakfast including proteins, carbohydrates, and vitamins. For instance, an omelette with vegetables and a slice of bread.",
                            Status = 1,
                            Title = "Prepare Breakfast",
                            UserId = 99
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2023, 9, 1, 18, 45, 48, 221, DateTimeKind.Local).AddTicks(8997),
                            Description = "Dedicate some time to physical exercises. It will help awaken your body, improve your mood, and get you ready for the day.",
                            Status = 2,
                            Title = "Morning Workout",
                            UserId = 99
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2023, 7, 9, 18, 45, 48, 221, DateTimeKind.Local).AddTicks(9005),
                            Description = "Check your email and respond to important messages. This will help you stay connected with colleagues, friends, and partners",
                            Status = 3,
                            Title = "Respond to Emails",
                            UserId = 99
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2023, 9, 9, 17, 25, 48, 221, DateTimeKind.Local).AddTicks(9015),
                            Description = "Create a task list for the day and prioritize them. This will help you organize your work and achieve your goals.",
                            Status = 1,
                            Title = "Plan Your Work Day",
                            UserId = 93
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2023, 9, 7, 18, 45, 48, 221, DateTimeKind.Local).AddTicks(9020),
                            Description = "Engage in your main tasks according to the list. Avoid distractions and try to focus on one task at a time.",
                            Status = 1,
                            Title = "Productive Work Time",
                            UserId = 99
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2023, 9, 6, 18, 45, 48, 221, DateTimeKind.Local).AddTicks(9022),
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
