﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkAssistantApp.Data;

namespace WorkAssistantApp.Data.Migrations
{
    [DbContext(typeof(WorkAssistantDbContext))]
    partial class WorkAssistantDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WorkAssistantApp.Data.Models.ApplicationUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WorkAssistantApp.Data.Models.Project", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long?>("CreatedById")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ModifiedById")
                        .HasColumnType("bigint");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ProjectManagerId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ModifiedById");

                    b.HasIndex("ProjectManagerId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("WorkAssistantApp.Data.Models.StatusCurrent", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ModifiedById")
                        .HasColumnType("bigint");

                    b.Property<long?>("ProjectId")
                        .HasColumnType("bigint");

                    b.Property<int>("StartHourOnFridayId")
                        .HasColumnType("int");

                    b.Property<int>("StartHourOnMondayId")
                        .HasColumnType("int");

                    b.Property<int>("StartHourOnThursdayId")
                        .HasColumnType("int");

                    b.Property<int>("StartHourOnTuesdayId")
                        .HasColumnType("int");

                    b.Property<int>("StartHourOnWednesdayId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StatusAvailableFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("StatusAvailableTo")
                        .HasColumnType("datetime2");

                    b.Property<bool>("StatusAvailableUse")
                        .HasColumnType("bit");

                    b.Property<string>("StatusDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ModifiedById");

                    b.HasIndex("ProjectId");

                    b.HasIndex("StartHourOnFridayId");

                    b.HasIndex("StartHourOnMondayId");

                    b.HasIndex("StartHourOnThursdayId");

                    b.HasIndex("StartHourOnTuesdayId");

                    b.HasIndex("StartHourOnWednesdayId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("StatusCurrents");
                });

            modelBuilder.Entity("WorkAssistantApp.Data.Models.StatusEvent", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long?>("CreatedById")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ModifiedById")
                        .HasColumnType("bigint");

                    b.Property<long?>("ProjectId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("To")
                        .HasColumnType("datetime2");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ModifiedById");

                    b.HasIndex("ProjectId");

                    b.HasIndex("TypeId");

                    b.HasIndex("UserId");

                    b.ToTable("StatusEvents");
                });

            modelBuilder.Entity("WorkAssistantApp.Data.Models.StatusEventType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StatusEventType");
                });

            modelBuilder.Entity("WorkAssistantApp.Data.Models.StatusStartHour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Hour")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StatusStartHour");
                });

            modelBuilder.Entity("WorkAssistantApp.Data.Models.Project", b =>
                {
                    b.HasOne("WorkAssistantApp.Data.Models.ApplicationUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("WorkAssistantApp.Data.Models.ApplicationUser", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("WorkAssistantApp.Data.Models.ApplicationUser", "ProjectManager")
                        .WithMany()
                        .HasForeignKey("ProjectManagerId")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("WorkAssistantApp.Data.Models.StatusCurrent", b =>
                {
                    b.HasOne("WorkAssistantApp.Data.Models.ApplicationUser", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("WorkAssistantApp.Data.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("WorkAssistantApp.Data.Models.StatusStartHour", "StartHourOnFriday")
                        .WithMany()
                        .HasForeignKey("StartHourOnFridayId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("WorkAssistantApp.Data.Models.StatusStartHour", "StartHourOnMonday")
                        .WithMany()
                        .HasForeignKey("StartHourOnMondayId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("WorkAssistantApp.Data.Models.StatusStartHour", "StartHourOnThursday")
                        .WithMany()
                        .HasForeignKey("StartHourOnThursdayId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("WorkAssistantApp.Data.Models.StatusStartHour", "StartHourOnTuesday")
                        .WithMany()
                        .HasForeignKey("StartHourOnTuesdayId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("WorkAssistantApp.Data.Models.StatusStartHour", "StartHourOnWednesday")
                        .WithMany()
                        .HasForeignKey("StartHourOnWednesdayId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("WorkAssistantApp.Data.Models.ApplicationUser", "User")
                        .WithOne("StatusCurrent")
                        .HasForeignKey("WorkAssistantApp.Data.Models.StatusCurrent", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WorkAssistantApp.Data.Models.StatusEvent", b =>
                {
                    b.HasOne("WorkAssistantApp.Data.Models.ApplicationUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("WorkAssistantApp.Data.Models.ApplicationUser", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("WorkAssistantApp.Data.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("WorkAssistantApp.Data.Models.StatusEventType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorkAssistantApp.Data.Models.ApplicationUser", "User")
                        .WithMany("StatusEvents")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
