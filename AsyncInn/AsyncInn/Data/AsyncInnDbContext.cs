using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data
{
    public class AsyncInnDbContext : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<RoomAmenity> RoomAmenities { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public AsyncInnDbContext(DbContextOptions options) : base(options)
        
        {

        }
        /// <summary>
        /// Going to clean up this monster, but this is our seeding data and on lines 37/38 creating the key for the two that do not have their own primary key.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>().HasData(new Hotel { ID = 1, Name = "Cozy Hotel", City = "Redmond", Country = "USA", PhoneNumber = "555-555-5555", State = "WA", StreetAddress = "6969 Apple Street" });
            modelBuilder.Entity<Hotel>().HasData(new Hotel { ID = 2, Name = "Rivendell Hotel", City = "New Orleans", Country = "USA", PhoneNumber = "555-555-5555", State = "LA", StreetAddress = "6969 Mardi Gras Street" });
            modelBuilder.Entity<Hotel>().HasData(new Hotel { ID = 3, Name = "Honey BBQ Hotel", City = "Nashville", Country = "USA", PhoneNumber = "555-555-5555", State = "TN", StreetAddress = "6969 Whiskey Street" });
            modelBuilder.Entity<Room>().HasData(new Room { ID = 1, Name = "Frodo View", Layout = "Studio" });
            modelBuilder.Entity<Room>().HasData(new Room { ID = 2, Name = "ShadowFax View", Layout = "One-Bedroom" });
            modelBuilder.Entity<Room>().HasData(new Room { ID = 3, Name = "Gandolf View", Layout = "Two-Bedroom" });
            modelBuilder.Entity<Amenity>().HasData(new Amenity { ID = 1, Name = "Mini Bar" });
            modelBuilder.Entity<Amenity>().HasData(new Amenity { ID = 2, Name = "Mini Fridge" });
            modelBuilder.Entity<Amenity>().HasData(new Amenity { ID = 3, Name = "Mini Shower" });
            modelBuilder.Entity<RoomAmenity>().HasKey(RoomAmenity => new { RoomAmenity.AmenityID, RoomAmenity.RoomID });
            modelBuilder.Entity<HotelRoom>().HasKey(HotelRoom => new { HotelRoom.HotelID, HotelRoom.RoomNumber });
            modelBuilder.Entity<HotelRoom>().HasData(new HotelRoom { RoomID = 1, RoomNumber = 23, HotelID = 1, Rate = 100, PetFriendly = true });
            modelBuilder.Entity<HotelRoom>().HasData(new HotelRoom { RoomID = 2, RoomNumber = 69, HotelID = 2, Rate = 169, PetFriendly = true });
            modelBuilder.Entity<HotelRoom>().HasData(new HotelRoom { RoomID = 3, RoomNumber = 88, HotelID = 3, Rate = 170, PetFriendly = false }
        );
        }

    }
}
