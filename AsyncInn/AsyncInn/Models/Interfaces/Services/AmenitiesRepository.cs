using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces.Services
{
    public class AmenitiesRepository : IAmenities
    {
        public Task<Amenity> Create(Amenity amenity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAmenity(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Amenity> GetAmenity(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Amenity>> GetHotels()
        {
            throw new NotImplementedException();
        }

        public Task<Amenity> UpdateAmenity(int Id, Amenity amenity)
        {
            throw new NotImplementedException();
        }
    }
}
