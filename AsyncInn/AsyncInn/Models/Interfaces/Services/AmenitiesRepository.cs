using AsyncInn.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces.Services
{
    public class AmenitiesRepository : IAmenity
    {
        public AsyncInnDbContext _context;

        public AmenitiesRepository(AsyncInnDbContext context)
        {
            _context = context;
        }
        public async Task<Amenity> CreateAmenity(Amenity amenity)
        {
            _context.Entry(amenity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return amenity;
        }

        public async Task<Amenity> GetAmenity(int Id)
        {
            Amenity amenity = await _context.Amenities.FindAsync(Id);
            var room = await _context.RoomAmenities.Where(x => x.AmenityID == Id)
                                                   .Include(x => x.room)
                                                   .ToListAsync();
            amenity.RoomAmenities = room;
            return amenity;
        }

        public async Task<List<Amenity>> GetAmenities()
        {
            var amenities = await _context.Amenities.ToListAsync();
            return amenities;
        }

        public async Task<Amenity> UpdateAmenity(int Id, Amenity amenity)
        {
            _context.Entry(amenity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return amenity;
        }

        public async Task DeleteAmenity(int Id)
        {
            Amenity amenity = await GetAmenity(Id);
            _context.Entry(amenity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
