using AsyncInn.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IRoom
    {
        Task<RoomDTO> Create(RoomDTO roomDTO);
        Task<RoomDTO> GetRoom(int Id);
        Task<List<RoomDTO>> GetRooms();
        Task<RoomDTO> UpdateRoom(RoomDTO roomDTO);
        Task DeleteRoom(int Id);
        Task AddAmenityToRoom(int RoomID, int amenityID);
        Task RemoveAmenity(int RoomID, int amenityID);
    }
}
