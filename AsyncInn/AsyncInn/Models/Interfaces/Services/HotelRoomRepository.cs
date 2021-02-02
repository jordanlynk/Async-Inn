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
        

        public HotelRoomRepository(AsyncInnDbContext context)
        {
            _context = context;
           
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

        public async Task<HotelRoom> GetHotelRoom(int hotelId, int roomNumber)
        {
            return await _context.HotelRooms
                            .Where(h => h.HotelID == hotelId && h.RoomNumber == roomNumber)
                                .FirstOrDefaultAsync();
        }

        public async Task<List<HotelRoom>> GetHotelRooms(int HotelId)
        {
            return await _context.HotelRooms
                            .Where(h => h.HotelID == HotelId)
                                .ToListAsync();

        }

        public async Task RemoveRoomFromHotel(int roomNumber, int hotelID)
        {
            var result = await _context.HotelRooms.FirstOrDefaultAsync(x => x.HotelID == hotelID && x.RoomNumber == roomNumber );

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
