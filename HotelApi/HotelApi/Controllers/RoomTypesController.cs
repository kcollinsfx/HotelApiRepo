﻿using System;
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
    public class RoomTypesController : ControllerBase
    {
        private readonly HotelDbContext _context;

        public RoomTypesController(HotelDbContext context)
        {
            _context = context;
        }

        // GET: api/RoomTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomType>>> GetRoomTypes()
        {
          if (_context.RoomTypes == null)
          {
              return NotFound();
          }
            return await _context.RoomTypes.ToListAsync();
        }

        // GET: api/RoomTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomType>> GetRoomType(int id)
        {
          if (_context.RoomTypes == null)
          {
              return NotFound();
          }
            var roomType = await _context.RoomTypes.FindAsync(id);

            if (roomType == null)
            {
                return NotFound();
            }

            return roomType;
        }

        // PUT: api/RoomTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomType(int id, RoomType roomType)
        {
            if (id != roomType.RoomTypeId)
            {
                return BadRequest();
            }

            _context.Entry(roomType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomTypeExists(id))
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

        // POST: api/RoomTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoomType>> PostRoomType(RoomType roomType)
        {
          if (_context.RoomTypes == null)
          {
              return Problem("Entity set 'HotelDbContext.RoomTypes'  is null.");
          }
            _context.RoomTypes.Add(roomType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoomType", new { id = roomType.RoomTypeId }, roomType);
        }

        // DELETE: api/RoomTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomType(int id)
        {
            if (_context.RoomTypes == null)
            {
                return NotFound();
            }
            var roomType = await _context.RoomTypes.FindAsync(id);
            if (roomType == null)
            {
                return NotFound();
            }

            _context.RoomTypes.Remove(roomType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomTypeExists(int id)
        {
            return (_context.RoomTypes?.Any(e => e.RoomTypeId == id)).GetValueOrDefault();
        }
    }
}
