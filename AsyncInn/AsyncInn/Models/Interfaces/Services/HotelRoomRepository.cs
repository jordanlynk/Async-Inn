using AsyncInn.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Models.Interfaces.Services
{
    public class HotelRoomRepository : IHotelRoom
    {
        private readonly AsyncInnDbContext _context;
        private readonly IRoom _rooms;

        public HotelRoomRepository(AsyncInnDbContext context, IRoom rooms)
        {
            _context = context;
            _rooms = rooms;
        }
        public async Task AddRoomToHotel(int RoomID, int HotelID, int RoomNumber, bool PetFriendly, decimal Rate)
        {
            HotelRoom hotelRoom = new HotelRoom()
            {
                RoomID = RoomID,
                HotelID = HotelID,
                RoomNumber = RoomNumber,
                PetFriendly = PetFriendly,
                Rate = Rate
            };

            _context.Entry(hotelRoom).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task<HotelRoom> CreateHotelRoom(HotelRoom hotelRoom)
        {
            _context.Entry(hotelRoom).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return hotelRoom;
        }

        public async Task DeleteHotelRoom(int hotelId, int roomNumber)
        {
            HotelRoom hotelRoom = await GetHotelRoom(hotelId, roomNumber);
            _context.Entry(hotelRoom).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<HotelRoom> GetHotelRoom(int HotelId, int roomNumber)
        {
            return await _context.HotelRooms
                         .Where(h => h.HotelID == HotelId && h.RoomNumber == roomNumber)
                         .Include(h => h.hotel)
                         .ThenInclude(r => r.HotelRooms)
                         .FirstOrDefaultAsync();
        }

        public async Task<List<HotelRoom>> GetHotelRooms(int HotelId, int roomNumber)
        {
            return await _context.HotelRooms
                         .Where(h => h.HotelID == HotelId && h.RoomNumber == roomNumber)
                         .Include(h => h.hotel)
                         .ThenInclude(r => r.HotelRooms)
                         .ToListAsync();

        }

        public async Task RemoveRoomFromHotel(int RoomID, int HotelID)
        {
            var result = await _context.HotelRooms.FirstOrDefaultAsync(x => x.HotelID == HotelID && x.RoomID == RoomID );

            _context.Entry(result).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task<HotelRoom> UpdateHotelRoom(HotelRoom hotelRoom)
        {
            _context.Entry(hotelRoom).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotelRoom;
        }
    }
}
