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
        public DbSet<Hotels> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public AsyncInnDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)        
        {
            modelBuilder.Entity<Hotels>().HasData(new Hotels { ID = 1, Name = "Cozy Hotel", City = "Redmond", Country = "USA", PhoneNumber = "555-555-5555", State = "WA", StreetAddress = "6969 Apple Street"});
            modelBuilder.Entity<Hotels>().HasData(new Hotels { ID = 2, Name = "Rivendell Hotel", City = "New Orleans", Country = "USA", PhoneNumber = "555-555-5555", State = "LA", StreetAddress = "6969 Mardi Gras Street" });
            modelBuilder.Entity<Hotels>().HasData(new Hotels { ID = 3, Name = "Honey BBQ Hotel", City = "Nashville", Country = "USA", PhoneNumber = "555-555-5555", State = "TN", StreetAddress = "6969 Whiskey Street" });
            modelBuilder.Entity<Room>().HasData(new Room { ID = 1, Name = "Frodo View", Layout = 0});
            modelBuilder.Entity<Room>().HasData(new Room { ID = 2, Name = "ShadowFax View", Layout = 1});
            modelBuilder.Entity<Room>().HasData(new Room { ID = 3, Name = "Gandolf View", Layout = 0 });
            modelBuilder.Entity<Amenity>().HasData(new Amenity { ID = 1, Name = "Mini Bar"});
            modelBuilder.Entity<Amenity>().HasData(new Amenity { ID = 2, Name = "Mini Fridge" });
            modelBuilder.Entity<Amenity>().HasData(new Amenity { ID = 3, Name = "Mini Shower" });

        }

    }
}
