﻿// <auto-generated />
using System;
using ApartmentRentingSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApartmentRentingSystem.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApartmentRentalDbContext))]
    partial class ApartmentRentalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApartmentRentingSystem.Domain.Models.ApartmentAds.ApartmentAd", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<int?>("LandlordId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("SquareMeters")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("LandlordId");

                    b.ToTable("ApartmentAds");
                });

            modelBuilder.Entity("ApartmentRentingSystem.Domain.Models.Landlords.Landlord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Landlords");
                });

            modelBuilder.Entity("ApartmentRentingSystem.Domain.Models.ApartmentAds.ApartmentAd", b =>
                {
                    b.HasOne("ApartmentRentingSystem.Domain.Models.Landlords.Landlord", null)
                        .WithMany("ApartmentAds")
                        .HasForeignKey("LandlordId");

                    b.OwnsOne("ApartmentRentingSystem.Domain.Models.ApartmentAds.Address", "Address", b1 =>
                        {
                            b1.Property<int>("ApartmentAdId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ApartmentAdId");

                            b1.ToTable("ApartmentAds");

                            b1.WithOwner()
                                .HasForeignKey("ApartmentAdId");
                        });

                    b.OwnsOne("ApartmentRentingSystem.Domain.Models.ApartmentAds.Options", "Options", b1 =>
                        {
                            b1.Property<int>("ApartmentAdId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<bool>("HasAirConditioner")
                                .HasColumnType("bit");

                            b1.Property<bool>("HasCoffeeMachine")
                                .HasColumnType("bit");

                            b1.Property<bool>("HasDishwasher")
                                .HasColumnType("bit");

                            b1.Property<bool>("HasFurniture")
                                .HasColumnType("bit");

                            b1.Property<bool>("HasGarden")
                                .HasColumnType("bit");

                            b1.Property<bool>("HasInternet")
                                .HasColumnType("bit");

                            b1.Property<bool>("HasLift")
                                .HasColumnType("bit");

                            b1.Property<bool>("HasMicrowave")
                                .HasColumnType("bit");

                            b1.Property<bool>("HasOven")
                                .HasColumnType("bit");

                            b1.Property<bool>("HasParking")
                                .HasColumnType("bit");

                            b1.Property<bool>("HasPhone")
                                .HasColumnType("bit");

                            b1.Property<bool>("HasRefrigerator")
                                .HasColumnType("bit");

                            b1.Property<bool>("HasTv")
                                .HasColumnType("bit");

                            b1.Property<bool>("HasWashingMachine")
                                .HasColumnType("bit");

                            b1.HasKey("ApartmentAdId");

                            b1.ToTable("ApartmentAds");

                            b1.WithOwner()
                                .HasForeignKey("ApartmentAdId");
                        });

                    b.OwnsOne("ApartmentRentingSystem.Domain.Models.ApartmentAds.Rooms", "Rooms", b1 =>
                        {
                            b1.Property<int>("ApartmentAdId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("NumberOfBalconies")
                                .HasColumnType("int")
                                .HasMaxLength(10);

                            b1.Property<int>("NumberOfBathrooms")
                                .HasColumnType("int")
                                .HasMaxLength(10);

                            b1.Property<int>("NumberOfBedrooms")
                                .HasColumnType("int")
                                .HasMaxLength(10);

                            b1.Property<int>("NumberOfRooms")
                                .HasColumnType("int")
                                .HasMaxLength(10);

                            b1.HasKey("ApartmentAdId");

                            b1.ToTable("ApartmentAds");

                            b1.WithOwner()
                                .HasForeignKey("ApartmentAdId");
                        });
                });

            modelBuilder.Entity("ApartmentRentingSystem.Domain.Models.Landlords.Landlord", b =>
                {
                    b.OwnsOne("ApartmentRentingSystem.Domain.Models.Landlords.PhoneNumber", "PhoneNumber", b1 =>
                        {
                            b1.Property<int>("LandlordId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("CountryCode")
                                .IsRequired()
                                .HasColumnType("nvarchar(10)")
                                .HasMaxLength(10);

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnType("nvarchar(20)")
                                .HasMaxLength(20);

                            b1.HasKey("LandlordId");

                            b1.ToTable("Landlords");

                            b1.WithOwner()
                                .HasForeignKey("LandlordId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
