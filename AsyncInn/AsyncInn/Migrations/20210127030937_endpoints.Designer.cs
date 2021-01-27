﻿// <auto-generated />
using AsyncInn.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AsyncInn.Migrations
{
    [DbContext(typeof(AsyncInnDbContext))]
    [Migration("20210127030937_endpoints")]
    partial class endpoints
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

            modelBuilder.Entity("AsyncInn.Models.Hotels", b =>
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
#pragma warning restore 612, 618
        }
    }
}
