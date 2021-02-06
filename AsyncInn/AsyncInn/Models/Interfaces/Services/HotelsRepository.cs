using AsyncInn.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Models.Interfaces.Services
{
    public class HotelsRepository : IHotel
    {
        private AsyncInnDbContext _context;
        /// <summary>
        /// sets up our reference to our database
        /// </summary>
        /// <param name="context"></param>
        public HotelsRepository(AsyncInnDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Creates a new hotel room 
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns>a hotel</returns>
        public async Task<Hotel> Create(Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return hotel;
        }
        /// <summary>
        /// This will get a single hotel room from our database
        /// </summary>
        /// <param name="Id">gets the hotel based on specific id</param>
        /// <returns>the room called upon</returns>
        public async Task<Hotel> GetHotel(int Id)
        {
            Hotel hotel = await _context.Hotels.FindAsync(Id);
            return hotel;
        }
        /// <summary>
        /// Gets a list of hotel rooms 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Hotel>> GetHotels()
        {
            var hotel = await _context.Hotels.ToListAsync();
            return hotel;
        }
        /// <summary>
        /// Updates a single hotel room 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="hotel"></param>
        /// <returns>the hotel room called upon</returns>
        public async Task<Hotel> UpdateHotel(int Id, Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotel;
        }
        /// <summary>
        /// Deletes one hotel room
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task DeleteHotel(int Id)
        {
            Hotel hotel = await GetHotel(Id);
            _context.Entry(hotel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
