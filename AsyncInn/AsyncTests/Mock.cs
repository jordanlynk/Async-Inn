using AsyncInn.Data;
using AsyncInn.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AsyncTests
{
    public abstract class Mock : IDisposable
    {
        private readonly SqliteConnection _connection;
        protected readonly AsyncInnDbContext _db;

        public Mock()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();
            _db = new AsyncInnDbContext(
                new DbContextOptionsBuilder<AsyncInnDbContext>()
                .UseSqlite(_connection)
                .Options);
            _db.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _db?.Dispose();
            _connection?.Dispose();
        }
        [Fact]
        protected async Task<Amenity> CreateAndSaveTestAmenity()
        {
            var amenity = new Amenity()
            {
                Name = "HotTub",
                ID = 48
            };
            _db.Add(amenity);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, amenity.ID);
            return amenity;
        }
        [Fact]
        protected async Task<Room> CreateAndSaveTestRoom()
        {
            var room = new Room()
            {
                ID = 99,
                Name = "Gandalf's Suite",
                Layout = "Two-Bedroom"
            };
            _db.Add(room);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, room.ID);
            return room;
        }
    }
}
    

