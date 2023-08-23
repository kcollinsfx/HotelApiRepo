using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelApi.Models;

namespace HotelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservedRoomsController : ControllerBase
    {
        private readonly HotelDbContext _context;

        public ReservedRoomsController(HotelDbContext context)
        {
            _context = context;
        }

        // GET: api/ReservedRooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservedRoom>>> GetReservedRooms()
        {
          if (_context.ReservedRooms == null)
          {
              return NotFound();
          }
            return await _context.ReservedRooms.ToListAsync();
        }

        // GET: api/ReservedRooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReservedRoom>> GetReservedRoom(int id)
        {
          if (_context.ReservedRooms == null)
          {
              return NotFound();
          }
            var reservedRoom = await _context.ReservedRooms.FindAsync(id);

            if (reservedRoom == null)
            {
                return NotFound();
            }

            return reservedRoom;
        }

        // PUT: api/ReservedRooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservedRoom(int id, ReservedRoom reservedRoom)
        {
            if (id != reservedRoom.ReservedRoomId)
            {
                return BadRequest();
            }

            _context.Entry(reservedRoom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservedRoomExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ReservedRooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReservedRoom>> PostReservedRoom(ReservedRoom reservedRoom)
        {
          if (_context.ReservedRooms == null)
          {
              return Problem("Entity set 'HotelDbContext.ReservedRooms'  is null.");
          }
            _context.ReservedRooms.Add(reservedRoom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReservedRoom", new { id = reservedRoom.ReservedRoomId }, reservedRoom);
        }

        // DELETE: api/ReservedRooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservedRoom(int id)
        {
            if (_context.ReservedRooms == null)
            {
                return NotFound();
            }
            var reservedRoom = await _context.ReservedRooms.FindAsync(id);
            if (reservedRoom == null)
            {
                return NotFound();
            }

            _context.ReservedRooms.Remove(reservedRoom);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReservedRoomExists(int id)
        {
            return (_context.ReservedRooms?.Any(e => e.ReservedRoomId == id)).GetValueOrDefault();
        }
    }
}
