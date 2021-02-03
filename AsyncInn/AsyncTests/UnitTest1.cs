using AsyncInn.Models.DTOs;
using AsyncInn.Models.Interfaces;
using AsyncInn.Models.Interfaces.Services;
using System;
using System.Threading.Tasks;
using Xunit;


namespace AsyncTests
{
    public class UnitTest1 : Mock

    {   
        private IAmenity BuildRepository()
        {
            return new AmenitiesRepository(_db);
        }
        
        [Fact]
        public async Task CanGetAllSpecifiedAmenities()
        {
            var repository = BuildRepository();

            var saved = await repository.GetAmenities();

            Assert.Equal(3, saved.Count);
            Assert.Equal("Mini Bar", saved[0].Name);
        }

        [Fact]
        public async Task CanUpdateAmenity()
        {
            var amenityUpdate = new AmenityDTO
            {
                ID = 1,
                Name = "HotTub",
            };

            var repository = BuildRepository();
            await repository.UpdateAmenity(amenityUpdate);
            // Amenity ID is 5 due to 3 previously seeded Amenities from DbContext
            var result = await repository.GetAmenity(1);
            Assert.Equal(amenityUpdate.Name, result.Name);
        }

    }
}
