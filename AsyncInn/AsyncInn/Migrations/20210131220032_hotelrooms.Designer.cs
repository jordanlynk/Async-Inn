﻿// <auto-generated />
using System;
using AsyncInn.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AsyncInn.Migrations
{
    [DbContext(typeof(AsyncInnDbContext))]
    [Migration("20210131220032_hotelrooms")]
    partial class hotelrooms
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AsyncInn.Models.Amenity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Amenities");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Mini Bar"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Mini Fridge"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Mini Shower"
                        });
                });

            modelBuilder.Entity("AsyncInn.Models.Hotel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            City = "Redmond",
                            Country = "USA",
                            Name = "Cozy Hotel",
                            PhoneNumber = "555-555-5555",
                            State = "WA",
                            StreetAddress = "6969 Apple Street"
                        },
                        new
                        {
                            ID = 2,
                            City = "New Orleans",
                            Country = "USA",
                            Name = "Rivendell Hotel",
                            PhoneNumber = "555-555-5555",
                            State = "LA",
                            StreetAddress = "6969 Mardi Gras Street"
                        },
                        new
                        {
                            ID = 3,
                            City = "Nashville",
                            Country = "USA",
                            Name = "Honey BBQ Hotel",
                            PhoneNumber = "555-555-5555",
                            State = "TN",
                            StreetAddress = "6969 Whiskey Street"
                        });
                });

            modelBuilder.Entity("AsyncInn.Models.HotelRoom", b =>
                {
                    b.Property<int>("HotelID")
                        .HasColumnType("int");

                    b.Property<int>("RoomID")
                        .HasColumnType("int");

                    b.Property<int?>("AmenityID")
                        .HasColumnType("int");

                    b.Property<bool>("PetFriendly")
                        .HasColumnType("bit");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.HasKey("HotelID", "RoomID");

                    b.HasIndex("AmenityID");

                    b.HasIndex("RoomID");

                    b.ToTable("HotelRooms");

                    b.HasData(
                        new
                        {
                            HotelID = 1,
                            RoomID = 1,
                            PetFriendly = true,
                            Rate = 100m,
                            RoomNumber = 23
                        },
                        new
                        {
                            HotelID = 2,
                            RoomID = 2,
                            PetFriendly = true,
                            Rate = 169m,
                            RoomNumber = 69
                        },
                        new
                        {
                            HotelID = 3,
                            RoomID = 3,
                            PetFriendly = false,
                            Rate = 170m,
                            RoomNumber = 88
                        });
                });

            modelBuilder.Entity("AsyncInn.Models.Room", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Layout")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Layout = 0,
                            Name = "Frodo View"
                        },
                        new
                        {
                            ID = 2,
                            Layout = 1,
                            Name = "ShadowFax View"
                        },
                        new
                        {
                            ID = 3,
                            Layout = 0,
                            Name = "Gandolf View"
                        });
                });

            modelBuilder.Entity("AsyncInn.Models.RoomAmenity", b =>
                {
                    b.Property<int>("AmenityID")
                        .HasColumnType("int");

                    b.Property<int>("RoomID")
                        .HasColumnType("int");

                    b.HasKey("AmenityID", "RoomID");

                    b.HasIndex("RoomID");

                    b.ToTable("RoomAmenities");
                });

            modelBuilder.Entity("AsyncInn.Models.HotelRoom", b =>
                {
                    b.HasOne("AsyncInn.Models.Amenity", null)
                        .WithMany("HotelRooms")
                        .HasForeignKey("AmenityID");

                    b.HasOne("AsyncInn.Models.Hotel", "hotel")
                        .WithMany("HotelRooms")
                        .HasForeignKey("HotelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AsyncInn.Models.Room", "room")
                        .WithMany("HotelRooms")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AsyncInn.Models.RoomAmenity", b =>
                {
                    b.HasOne("AsyncInn.Models.Amenity", "amenity")
                        .WithMany("RoomAmenities")
                        .HasForeignKey("AmenityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AsyncInn.Models.Room", "room")
                        .WithMany("RoomAmenities")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
