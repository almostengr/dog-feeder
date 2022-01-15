﻿// <auto-generated />
using System;
using Almostengr.PetFeeder.BackEnd.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Almostengr.PetFeeder.Migrations
{
    [DbContext(typeof(PetFeederContext))]
    partial class PetFeederContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("Almostengr.PetFeeder.BackEnd.Models.Feeding", b =>
                {
                    b.Property<int>("FeedingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Amount")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int>("FeedingType")
                        .HasColumnType("INTEGER");

                    b.HasKey("FeedingId");

                    b.ToTable("Feedings");
                });

            modelBuilder.Entity("Almostengr.PetFeeder.BackEnd.Models.Schedule", b =>
                {
                    b.Property<int>("ScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<double>("FeedingAmount")
                        .HasColumnType("REAL");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("TEXT");

                    b.Property<int>("ScheduleType")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ScheduledTime")
                        .HasColumnType("TEXT");

                    b.HasKey("ScheduleId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("Almostengr.PetFeeder.BackEnd.Models.SystemSetting", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("Name");

                    b.ToTable("SystemSettings");
                });
#pragma warning restore 612, 618
        }
    }
}
