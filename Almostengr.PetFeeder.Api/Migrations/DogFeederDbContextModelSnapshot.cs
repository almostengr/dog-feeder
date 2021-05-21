﻿// <auto-generated />
using System;
using Almostengr.PetFeeder.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Almostengr.PetFeeder.Api.Migrations
{
    [DbContext(typeof(DogFeederDbContext))]
    partial class DogFeederDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Almostengr.PetFeeder.Api.Models.Feeding", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("feeding");
                });

            modelBuilder.Entity("Almostengr.PetFeeder.Api.Models.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("FeedingAmount")
                        .HasColumnType("double");

                    b.Property<int>("Frequency")
                        .HasColumnType("int");

                    b.Property<string>("IpAddress")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("ScheduledTime")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("schedule");
                });
#pragma warning restore 612, 618
        }
    }
}
