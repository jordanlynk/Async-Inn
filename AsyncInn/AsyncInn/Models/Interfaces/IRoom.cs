using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IRoom
    {
        Task<Room> Create(Room room);
        Task<Room> GetRoom(int Id);
        Task<List<Room>> GetRooms();
        Task<Room> UpdateRoom(int Id, Room room);
        Task DeleteRoom(int Id);
    }
}
