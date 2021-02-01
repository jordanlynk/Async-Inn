using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AsyncInn.Models.Interfaces
{
    public interface IAmenity
    {
        Task<Amenity> CreateAmenity(Amenity amenity);
        Task<Amenity> GetAmenity(int Id);
        Task<List<Amenity>> GetAmenities();
        Task<Amenity> UpdateAmenity(int Id, Amenity amenity);
        Task DeleteAmenity(int Id);
    }
}
