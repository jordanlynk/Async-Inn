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
            Room room = await _context.Rooms.FindAsync(Id);
            return room;
        }

        public async Task<List<Room>> GetRooms()
        {
            var room = await _context.Rooms.ToListAsync();
            return room;
        }

        public async Task<Room> UpdateRoom(int Id, Room room)
        {
            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return room;
        }
    }
}
