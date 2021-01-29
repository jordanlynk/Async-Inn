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

        public async Task DeleteRoom(int Id)
        {
            HotelRoom hotelRoom = await GetHotelRoom(Id);
            _context.Entry(hotelRoom).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<HotelRoom> GetHotelRoom(int HotelId,int roomNumber)
        {
            return await _context.HotelRoom
                         .Include(h => h.HotelRooms)
                         .ThenInclude(r => r.)
                         .FirstOrDefaultAsync(h => h.ID == Id);
        }

        public Task<List<HotelRoom>> GetHotelRooms()
        {
            throw new NotImplementedException();
        }

        public Task RemoveRoomFromHotel(int RoomID, int HotelID)
        {
            throw new NotImplementedException();
        }

        public Task<Room> UpdateHotelRoom(int Id, HotelRoom hotelRoom)
        {
            throw new NotImplementedException();
        }
    }
}
