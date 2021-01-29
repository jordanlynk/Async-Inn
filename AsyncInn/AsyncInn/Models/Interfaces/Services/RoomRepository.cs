using AsyncInn.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace AsyncInn.Models.Interfaces.Services
{
    public class RoomRepository : IRoom
    {
        private AsyncInnDbContext _context;

        public RoomRepository(AsyncInnDbContext context)
        {
            _context = context;
        }
        public async Task<Room> Create(Room room)
        {
            _context.Entry(room).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return room;

        }

        public async Task DeleteRoom(int Id)
        {
            Room room = await GetRoom(Id);
            _context.Entry(room).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Room> GetRoom(int Id)
        {
           return await _context.Rooms
                        .Include(a => a.RoomAmenities)
                        .ThenInclude(r => r.amenity)
                        .FirstOrDefaultAsync(a => a.ID == Id);
        }

        public async Task<List<Room>> GetRooms()
        {
            return await _context.Rooms
                         .Include(a => a.RoomAmenities)
                         .ThenInclude(r => r.amenity)
                         .ToListAsync();
        }

        public async Task<Room> UpdateRoom(int Id, Room room)
        {
            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task AddAmenityToRoom(int RoomID, int amenityID)
        {
            RoomAmenity RoomAmenity = new RoomAmenity()
            {
                RoomID = RoomID,
                AmenityID = amenityID
            };

            _context.Entry(RoomAmenity).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAmenity(int RoomID, int amenityID)
        {
            var result = await _context.RoomAmenities.FirstOrDefaultAsync(x => x.RoomID == RoomID && x.AmenityID == amenityID);

            _context.Entry(result).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }
    }
}
