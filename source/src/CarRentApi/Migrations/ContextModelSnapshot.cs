﻿// <auto-generated />
using System;
using CarRentApi.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarRentApi.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarRentApi.CarManagement.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CarClassId")
                        .HasColumnType("int");

                    b.Property<string>("LicensePlate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarClassId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1000,
                            Brand = "Volvo",
                            CarClassId = 1001,
                            LicensePlate = "SG 456845",
                            Model = "V50"
                        },
                        new
                        {
                            Id = 1001,
                            Brand = "Audi",
                            CarClassId = 1000,
                            LicensePlate = "TG 34253",
                            Model = "A8"
                        });
                });

            modelBuilder.Entity("CarRentApi.CarManagement.CarClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PricePerDay")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("CarClasses");

                    b.HasData(
                        new
                        {
                            Id = 1000,
                            Description = "Luxury",
                            PricePerDay = 200.0
                        },
                        new
                        {
                            Id = 1001,
                            Description = "Medium",
                            PricePerDay = 100.0
                        },
                        new
                        {
                            Id = 1002,
                            Description = "Basic",
                            PricePerDay = 50.0
                        });
                });

            modelBuilder.Entity("CarRentApi.CustomerManagement.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Place")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Zip")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1000,
                            Country = "Switzerland",
                            FirstName = "Raphael",
                            LastName = "Wirth",
                            Place = "St. Gallen",
                            Street = "Musterstrasse",
                            StreetNumber = "12a",
                            Zip = 9000
                        },
                        new
                        {
                            Id = 1001,
                            Country = "Switzerland",
                            FirstName = "Hans",
                            LastName = "Müller",
                            Place = "Goldach",
                            Street = "Bahnhofweg",
                            StreetNumber = "24",
                            Zip = 9403
                        });
                });

            modelBuilder.Entity("CarRentApi.ReservationManagement.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            Id = 1000,
                            CarId = 1000,
                            CustomerId = 1000,
                            EndDate = new DateTime(2021, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("CarRentApi.CarManagement.Car", b =>
                {
                    b.HasOne("CarRentApi.CarManagement.CarClass", "CarClass")
                        .WithMany()
                        .HasForeignKey("CarClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarClass");
                });

            modelBuilder.Entity("CarRentApi.ReservationManagement.Reservation", b =>
                {
                    b.HasOne("CarRentApi.CarManagement.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRentApi.CustomerManagement.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Customer");
                });
#pragma warning restore 612, 618
        }
    }
}
