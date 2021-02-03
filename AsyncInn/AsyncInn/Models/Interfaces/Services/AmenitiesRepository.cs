using AsyncInn.Data;
using AsyncInn.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces.Services
{
    public class AmenitiesRepository : IAmenity
    {
        private readonly AsyncInnDbContext _context;

        public AmenitiesRepository(AsyncInnDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// This will create a new amenity in the DB
        /// </summary>
        /// <param name="amenity">Amenity to be added to DB as DTO</param>
        /// <returns>This is the result of add the amenityDTO</returns>
        public async Task<AmenityDTO> CreateAmenity(AmenityDTO amenity)
        {
            _context.Entry(amenity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return amenity;
        }

        /// <summary>
        /// This gets a specific amenity DTO from the DB 
        /// </summary>
        /// <param name="Id">Id for amenity to be retrieved</param>
        /// <returns>Successful result of specified amentiyDBO</returns>
        public async Task<AmenityDTO> GetAmenity(int Id)
        {
            var result = await _context.Amenities.FindAsync(Id);
            AmenityDTO amenityDTO = new AmenityDTO
            {
                ID = result.ID,
                Name = result.Name
            };
            return amenityDTO;
        }
        
          
        public async Task<List<AmenityDTO>> GetAmenities()
        {
            List<Amenity> result = await _context.Amenities.ToListAsync();
            var amenities = new List<AmenityDTO>();

            foreach (var amenity in result)
            {
                amenities.Add(await GetAmenity(amenity.ID));
            }
            return amenities;
        }
        /// <summary>
        /// This will update the details of a given amenity
        /// </summary>
        /// <param name="amenityDTO">the DTO that will need to be updated</param>
        /// <returns>Result of updated amenity</returns>
        public async Task<AmenityDTO> UpdateAmenity(AmenityDTO amenityDTO)
        {
            Amenity amenity = new Amenity
            {
                ID = amenityDTO.ID,
                Name = amenityDTO.Name
            };

            _context.Entry(amenity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return amenityDTO;
        }
        /// <summary>
        /// Deletes a specific amenity from the database 
        /// </summary>
        /// <param name="Id">the id of the amenity to be deleted</param>
        /// <returns>Task of completion</returns>
        public async Task DeleteAmenity(int Id)
        {
            Amenity amenity = await _context.Amenities.FindAsync(Id);
            _context.Entry(amenity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
