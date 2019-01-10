﻿// <auto-generated />
using System;
using GenijalnoParkingAssignment.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GenijalnoParkingAssignment.Migrations
{
    [DbContext(typeof(GenijalnoParkingContext))]
    partial class GenijalnoParkingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GenijalnoParkingAssignment.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("PhoneNumber")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("GenijalnoParkingAssignment.Models.Operator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Operators");
                });

            modelBuilder.Entity("GenijalnoParkingAssignment.Models.Parking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NumberOfFreeSlots");

                    b.Property<int>("TotalNumberOfSlots");

                    b.HasKey("Id");

                    b.ToTable("Parkings");
                });

            modelBuilder.Entity("GenijalnoParkingAssignment.Models.ParkingDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cost");

                    b.Property<int>("CustomerId");

                    b.Property<DateTime>("EntryDate");

                    b.Property<DateTime?>("ExitDate");

                    b.Property<int>("OperatorId");

                    b.Property<int>("ParkingId");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("OperatorId");

                    b.HasIndex("ParkingId");

                    b.ToTable("ParkingDetails");
                });

            modelBuilder.Entity("GenijalnoParkingAssignment.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId");

                    b.Property<string>("LicencePlateNumber");

                    b.Property<int>("VehicleType");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("GenijalnoParkingAssignment.Models.ParkingDetail", b =>
                {
                    b.HasOne("GenijalnoParkingAssignment.Models.Customer", "Customer")
                        .WithMany("ParkingDetails")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GenijalnoParkingAssignment.Models.Operator", "Operator")
                        .WithMany("ParkingDetails")
                        .HasForeignKey("OperatorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GenijalnoParkingAssignment.Models.Parking", "Parking")
                        .WithMany("ParkingDetails")
                        .HasForeignKey("ParkingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GenijalnoParkingAssignment.Models.Vehicle", b =>
                {
                    b.HasOne("GenijalnoParkingAssignment.Models.Customer", "Customer")
                        .WithOne("Vehicle")
                        .HasForeignKey("GenijalnoParkingAssignment.Models.Vehicle", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
