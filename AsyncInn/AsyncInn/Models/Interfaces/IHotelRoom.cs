using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotelRoom
    {
        Task<HotelRoom> CreateHotelRoom(HotelRoom hotelRoom);
        Task<HotelRoom> GetHotelRoom(int Id, int RoomNumber);
        Task<List<HotelRoom>> GetHotelRooms();
        Task<Room> UpdateHotelRoom(int Id, HotelRoom hotelRoom);
        Task DeleteRoom(int Id);
        Task AddRoomToHotel(int RoomID, int HotelID, int RoomNumber, bool PetFriendly, decimal Rate);
        Task RemoveRoomFromHotel(int RoomID, int HotelID);
    }
}
