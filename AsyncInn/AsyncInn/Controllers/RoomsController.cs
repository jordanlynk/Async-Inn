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
using AsyncInn.Models.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace AsyncInn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoom _room;

        public RoomsController(IRoom room)
        {
            _room = room;
        }

        [Authorize(Policy = "See Rooms")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDTO>>> GetRooms()
        {
            return Ok(await _room.GetRooms());
        }

        [Authorize(Policy = "See Rooms")]
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDTO>> GetRoom(int id)
        {
            RoomDTO room = await _room.GetRoom(id);

            if (room == null)
            {
                return NotFound();
            }

            return room;
        }

        [Authorize(Policy = "Update Rooms")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(RoomDTO roomDTO)
        {

            var updatedRoom = await _room.UpdateRoom(roomDTO);
            return Ok(updatedRoom);

        }

        [Authorize(Policy = "Create Rooms")]
        [HttpPost]
        public async Task<ActionResult<RoomDTO>> PostRoom(RoomDTO room)
        {
            await _room.Create(room);
            return CreatedAtAction("GetRoom", new { id = room.ID }, room);


        }

        [Authorize(Policy = "Delete Rooms")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Room>> DeleteRoom(int id)
        {
            await _room.DeleteRoom(id);
            return NoContent();
        }

        [Authorize(Policy = "Add Amenity To Room")]
        [HttpPost]
        [Route("{RoomID}/{AmenityID}")]

        public async Task<IActionResult> AddAmenityToRoom(int RoomID, int amenityID)
        {
            await _room.AddAmenityToRoom(RoomID, amenityID);
            return NoContent();
        }

        [Authorize(Policy = "Delete Amenity From Room")]
        [HttpDelete]
        [Route("{RoomID}/{AmenityID}")]

        public async Task<IActionResult> RemoveAmentityFromRoom(int roomId, int amenityId)
        {
            await _room.RemoveAmenity(roomId, amenityId);
            return NoContent();
        }

    }
}

