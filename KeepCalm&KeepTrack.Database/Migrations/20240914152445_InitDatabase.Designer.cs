﻿// <auto-generated />
using System;
using KeepCalm_KeepTrack.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KeepCalm_KeepTrack.Database.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240914152445_InitDatabase")]
    partial class InitDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("KeepCalm_KeepTrack.Database.Entities.ProjectEntity", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectId"));

                    b.Property<string>("ProjectDescription")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)")
                        .HasColumnName("Description");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Name");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects", (string)null);
                });

            modelBuilder.Entity("KeepCalm_KeepTrack.Database.Entities.TaskEntity", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskId"));

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("TaskDescription")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)")
                        .HasColumnName("Description");

                    b.Property<string>("TaskName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Name");

                    b.HasKey("TaskId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Tasks", (string)null);
                });

            modelBuilder.Entity("KeepCalm_KeepTrack.Database.Entities.TimeFrameEntity", b =>
                {
                    b.Property<int>("TimeFrameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TimeFrameId"));

                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeFrameEnd")
                        .HasColumnType("datetime2")
                        .HasColumnName("EndDateTime");

                    b.Property<DateTime>("TimeFrameStart")
                        .HasColumnType("datetime2")
                        .HasColumnName("StartDateTime");

                    b.Property<TimeSpan>("TimeFrameTime")
                        .HasColumnType("time")
                        .HasColumnName("TotalTime");

                    b.HasKey("TimeFrameId");

                    b.HasIndex("TaskId");

                    b.ToTable("TimeFrames", (string)null);
                });

            modelBuilder.Entity("KeepCalm_KeepTrack.Database.Entities.TaskEntity", b =>
                {
                    b.HasOne("KeepCalm_KeepTrack.Database.Entities.ProjectEntity", "ProjectEntity")
                        .WithMany("TaskEntityList")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProjectEntity");
                });

            modelBuilder.Entity("KeepCalm_KeepTrack.Database.Entities.TimeFrameEntity", b =>
                {
                    b.HasOne("KeepCalm_KeepTrack.Database.Entities.TaskEntity", "TaskEntity")
                        .WithMany("TimeFrameEntityList")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TaskEntity");
                });

            modelBuilder.Entity("KeepCalm_KeepTrack.Database.Entities.ProjectEntity", b =>
                {
                    b.Navigation("TaskEntityList");
                });

            modelBuilder.Entity("KeepCalm_KeepTrack.Database.Entities.TaskEntity", b =>
                {
                    b.Navigation("TimeFrameEntityList");
                });
#pragma warning restore 612, 618
        }
    }
}
