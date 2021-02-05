using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace AsyncInn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelRoomsController : ControllerBase
    {
        private readonly IHotelRoom _hotelRoom;

        public HotelRoomsController(IHotelRoom hotelRoom)
        {
            _hotelRoom = hotelRoom;
        }

        
        [HttpGet]
        [Route("Hotels/{hotelID}/Rooms")]
        public async Task<ActionResult<IEnumerable<HotelRoom>>> GetHotelRooms(int hotelId)
        {
            var hotelRoom = await _hotelRoom.GetHotelRooms(hotelId);
            return hotelRoom;
            
        }

        [HttpGet]
        [Route("Hotels/{hotelID}/Rooms/{roomNumber}")]
        public async Task<ActionResult<HotelRoom>> GetHotelRoom(int hotelId, int roomNumber)
        {
            var hotelRoom = await _hotelRoom.GetHotelRoom(hotelId, roomNumber);

            if (hotelRoom == null)
            {
                return NotFound();
            }

            return hotelRoom;
        }

        [Authorize(Policy = "Update HotelRooms")]
        [HttpPut]
        [Route("Hotels/{hotelID}/Rooms/{roomNumber}")]
        public async Task<IActionResult> PutHotelRoom(HotelRoom hotelRoom)
        {
            var updatedHotelRoom = await _hotelRoom.UpdateHotelRoom(hotelRoom);
            return Ok(updatedHotelRoom);
        }

        [Authorize(Policy = "Create HotelRooms")]
        [HttpPost]
        public async Task<ActionResult<HotelRoom>> PostHotelRoom(HotelRoom hotelRoom)
        {

            await _hotelRoom.CreateHotelRoom(hotelRoom);
            return CreatedAtAction("GetHotelRoom", new { HotelId = hotelRoom.HotelID, RoomID = hotelRoom.HotelID, RoomNumber = hotelRoom.HotelID, PetFriendly = hotelRoom.HotelID, Rate = hotelRoom.HotelID }, hotelRoom);
        }

        [Authorize(Policy = "Delete HotelRooms")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<HotelRoom>> DeleleHotelRoom(int hotelId, int roomNumber)
        {
            await _hotelRoom.DeleteHotelRoom(hotelId, roomNumber);
            return NoContent();
        }

        [Authorize(Policy = "Add Room To Hotel")]
        [HttpPost]
        [Route("Hotels{hotelID}/Rooms")]

        public async Task<IActionResult> AddRoomToHotel(int RoomID, int HotelID, int RoomNumber, bool PetFriendly, decimal Rate)
        {
            await _hotelRoom.AddRoomToHotel(RoomID, HotelID, RoomNumber, PetFriendly, Rate);
            return NoContent();
        }

        [HttpDelete]
        [Route("Hotels/{hotelId}/Rooms/{roomNumber}")]
        public async Task<IActionResult> DeleteRoomFromHotel(int roomNumber, int hotelId)
        {
            await _hotelRoom.RemoveRoomFromHotel(roomNumber, hotelId);
            return NoContent();
        }

    }
}
