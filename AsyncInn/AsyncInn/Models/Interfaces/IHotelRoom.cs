using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotelRoom
    {
        Task<HotelRoom> CreateHotelRoom(HotelRoom hotelRoom);
        Task<HotelRoom> GetHotelRoom(int hotelId, int roomNumber);
        Task<List<HotelRoom>> GetHotelRooms(int hotelId);
        Task<HotelRoom> UpdateHotelRoom(HotelRoom hotelRoom);
        Task DeleteHotelRoom(int hotelId, int roomNumber);
        Task AddRoomToHotel(int roomID, int hotelID, int roomNumber, bool PetFriendly, decimal Rate);
        Task RemoveRoomFromHotel(int roomNumber, int hotelID);
    }
}
