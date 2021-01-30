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

        // GET: api/HotelRooms
        [HttpGet]
        [Route("/Hotels/{HotelID}/Rooms")]
        public async Task<ActionResult<IEnumerable<HotelRoom>>> GetHotelRooms(int hotelId)
        {
            var hotelRoom = await _hotelRoom.GetHotelRooms(hotelId);
            return Ok(hotelRoom);
        }

        [HttpGet("{id}")]
        [Route("/Hotels/{HotelID}/Rooms/{RoomID}")]
        public async Task<ActionResult<HotelRoom>> GetHotelRoom(int hotelId, int RoomNumber)
        {
            var hotelRoom = await _hotelRoom.GetHotelRoom(hotelId, RoomNumber);

            if (hotelRoom == null)
            {
                return NotFound();
            }

            return hotelRoom;
        }

        // PUT: api/HotelRooms/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [Route("/Hotels/{HotelID}/Rooms")]
        public async Task<IActionResult> PutHotelRoom(HotelRoom hotelRoom)
        {
            var updatedHotelRoom = await _hotelRoom.UpdateHotelRoom(hotelRoom);
            return Ok(updatedHotelRoom);
        }

        // POST: api/HotelRooms
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Route("/Hotels/{HotelID}/Rooms/{RoomID}")]
        public async Task<ActionResult<HotelRoom>> PostHotelRoom(HotelRoom hotelRoom)
        {

            await _hotelRoom.CreateHotelRoom(hotelRoom);
            return CreatedAtAction("GetHotelRoom", new { HotelId = hotelRoom.HotelID, RoomID = hotelRoom.HotelID, RoomNumber = hotelRoom.HotelID, PetFriendly = hotelRoom.HotelID, Rate = hotelRoom.HotelID }, hotelRoom);
        }

        // DELETE: api/HotelRooms/5
        [HttpDelete("{id}")]
        [Route("/Hotels/{HotelID}/Rooms/{RoomID}")]
        public async Task<ActionResult<HotelRoom>> RemoveRoomFromHotel(int RoomID, int HotelID)
        {
            await _hotelRoom.DeleteHotelRoom(RoomID, HotelID);
            return NoContent();
        }

        [HttpPost]
        [Route("/Hotels{HotelID}/Rooms/{RoomID}")]

        public async Task<IActionResult> AddRoomToHotel(int RoomID, int HotelID, int RoomNumber, bool PetFriendly, decimal Rate)
        {
            await _hotelRoom.AddRoomToHotel(RoomID, HotelID, RoomNumber, PetFriendly, Rate);
            return NoContent();
        }

    }
}
