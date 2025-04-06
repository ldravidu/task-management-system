﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskManagementSystemApi.Data;

#nullable disable

namespace TaskManagementSystemApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250406095508_UpdateForeignKeyBehavior")]
    partial class UpdateForeignKeyBehavior
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.3");

            modelBuilder.Entity("ProjectUser", b =>
                {
                    b.Property<long>("MemberOfProjectsId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("MembersId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MemberOfProjectsId", "MembersId");

                    b.HasIndex("MembersId");

                    b.ToTable("ProjectMembers", (string)null);
                });

            modelBuilder.Entity("TaskManagementSystemApi.Models.Project", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("TaskManagementSystemApi.Models.Task", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long?>("AssignedToId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("CreatedById")
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly?>("DueDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Priority")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("ProjectId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AssignedToId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ProjectId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("TaskManagementSystemApi.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ProjectUser", b =>
                {
                    b.HasOne("TaskManagementSystemApi.Models.Project", null)
                        .WithMany()
                        .HasForeignKey("MemberOfProjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaskManagementSystemApi.Models.User", null)
                        .WithMany()
                        .HasForeignKey("MembersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TaskManagementSystemApi.Models.Task", b =>
                {
                    b.HasOne("TaskManagementSystemApi.Models.User", "AssignedTo")
                        .WithMany("AssignedTasks")
                        .HasForeignKey("AssignedToId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("TaskManagementSystemApi.Models.User", "CreatedBy")
                        .WithMany("CreatedTasks")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("TaskManagementSystemApi.Models.Project", "Project")
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("AssignedTo");

                    b.Navigation("CreatedBy");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("TaskManagementSystemApi.Models.Project", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("TaskManagementSystemApi.Models.User", b =>
                {
                    b.Navigation("AssignedTasks");

                    b.Navigation("CreatedTasks");
                });
#pragma warning restore 612, 618
        }
    }
}
