using AsyncInn.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Models.DTOs;

namespace AsyncInn.Models.Interfaces.Services
{
    public class RoomRepository : IRoom
    {
        private AsyncInnDbContext _context;

        public RoomRepository(AsyncInnDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// This will create a new room in the DB 
        /// </summary>
        /// <param name="room">This will be the room that is added into DB through DTO</param>
        /// <returns>This is the result of adding the roomDTO</returns>
        public async Task<RoomDTO> Create(RoomDTO room)
        {
            _context.Entry(room).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return room;

        }

        /// <summary>
        /// This will delete a specified room from the DB
        /// </summary>
        /// <param name="Id">this is the id of the room to be deleted</param>
        /// <returns>Completion of deleted room</returns>
        public async Task DeleteRoom(int Id)
        {
            RoomDTO room = await GetRoom(Id);
            _context.Entry(room).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// This will return a specific room in the DB 
        /// </summary>
        /// <param name="Id">ID for the specific room to be retrieved</param>
        /// <returns>The successful result of specified roomDTO</returns>
        public async Task<RoomDTO> GetRoom(int Id)
        {
           var room = await _context.Rooms
                        .Include(a => a.RoomAmenities)
                        .ThenInclude(r => r.amenity)
                        .ToListAsync();
            return room
            .Select(Room => new RoomDTO
            {
                ID = Room.ID,
                Name = Room.Name,
                Layout = Room.Layout,
                Amenities = Room.RoomAmenities

                .Select(a => new AmenityDTO
                {
                    ID = a.amenity.ID,
                    Name = a.amenity.Name

                }).ToList()

            }).FirstOrDefault();
           
        }
        /// <summary>
        /// This will return all the rooms in the DB
        /// </summary>
        /// <returns>Successful result of List of roomDTOs</returns>
        public async Task<List<RoomDTO>> GetRooms()
        {
            var rooms = await _context.Rooms
                         .Include(a => a.RoomAmenities)
                         .ThenInclude(r => r.amenity)
                         .ToListAsync();
            return rooms
            .Select(Room => new RoomDTO
            {
                ID = Room.ID,
                Name = Room.Name,
                Layout = Room.Layout,
                Amenities = Room.RoomAmenities

                .Select(a => new AmenityDTO
                {
                    ID = a.amenity.ID,
                    Name = a.amenity.Name
                }).ToList()

            }).ToList();
        }

        /// <summary>
        /// This will update the details of a given room
        /// </summary>
        /// <param name="roomDTO">This is the room to be updated through roomDTO</param>
        /// <returns>Successful result of updated roomDTO</returns>
        public async Task<RoomDTO> UpdateRoom(RoomDTO roomDTO)
        {
            Room room = new Room
            {
                ID = roomDTO.ID,
                Name = roomDTO.Name
            };
            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return roomDTO;
        }
        /// <summary>
        /// Adds a given amenity to a specific room by id
        /// </summary>
        /// <param name="RoomID">unique id for room</param>
        /// <param name="amenityID">unique id for amenity</param>
        /// <returns>Show of completion</returns>
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
        /// <summary>
        /// Removes a specific amenity from a specific room
        /// </summary>
        /// <param name="RoomID">Unique ID for room</param>
        /// <param name="amenityID">Unique ID for amenity to be removed</param>
        /// <returns>Proof of completion</returns>
        public async Task RemoveAmenity(int RoomID, int amenityID)
        {
            var result = await _context.RoomAmenities.FirstOrDefaultAsync(x => x.RoomID == RoomID && x.AmenityID == amenityID);

            _context.Entry(result).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }
    }
}
