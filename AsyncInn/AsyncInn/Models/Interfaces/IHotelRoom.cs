using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotelRoom
    {
        Task<HotelRoom> CreateHotelRoom(HotelRoom hotelRoom);
        Task<HotelRoom> GetHotelRoom(int hotelId, int RoomNumber);
        Task<List<HotelRoom>> GetHotelRooms(int hotelId);
        Task<HotelRoom> UpdateHotelRoom(HotelRoom hotelRoom);
        Task DeleteHotelRoom(int hotelId, int roomNumber);
        Task AddRoomToHotel(int RoomID, int HotelID, int RoomNumber, bool PetFriendly, decimal Rate);
        Task RemoveRoomFromHotel(int RoomID, int HotelID);
    }
}
