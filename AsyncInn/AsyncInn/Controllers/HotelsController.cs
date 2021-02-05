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
    public class HotelsController : ControllerBase

    {
        private readonly IHotel _hotel;

        public HotelsController(IHotel hotel)
        {
            _hotel = hotel;
        }

        [Authorize(Policy = "See Hotels")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotels()
        {
            return Ok(await _hotel.GetHotels());
        }

        [Authorize(Policy = "See Hotels")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotel(int id)
        {
            var hotel = await _hotel.GetHotel(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return hotel;
        }

        [Authorize(Policy = "Update Hotel")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, Hotel hotels)
        {
            if (id != hotels.ID)
            {
                return BadRequest();
            }

            var updatedHotel = await _hotel.UpdateHotel(id, hotels);
            return Ok(updatedHotel);
        }

        [Authorize(Policy = "Create Hotel")]
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotels(Hotel hotels)
        {
            await _hotel.Create(hotels);
            return CreatedAtAction("GetHotels", new { id = hotels.ID }, hotels);
        }

        [Authorize(Policy = "Delete Hotel")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Hotel>> DeleteHotels(int id)
        {
            await _hotel.DeleteHotel(id);
            return NoContent();
        }
    }
}

