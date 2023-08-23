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
    public class GuestInvoicesController : ControllerBase
    {
        private readonly HotelDbContext _context;

        public GuestInvoicesController(HotelDbContext context)
        {
            _context = context;
        }

        // GET: api/GuestInvoices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GuestInvoice>>> GetInvoices()
        {
          if (_context.Invoices == null)
          {
              return NotFound();
          }
            return await _context.Invoices.ToListAsync();
        }

        // GET: api/GuestInvoices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GuestInvoice>> GetGuestInvoice(int id)
        {
          if (_context.Invoices == null)
          {
              return NotFound();
          }
            var guestInvoice = await _context.Invoices.FindAsync(id);

            if (guestInvoice == null)
            {
                return NotFound();
            }

            return guestInvoice;
        }

        // PUT: api/GuestInvoices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGuestInvoice(int id, GuestInvoice guestInvoice)
        {
            if (id != guestInvoice.InvoiceId)
            {
                return BadRequest();
            }

            _context.Entry(guestInvoice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuestInvoiceExists(id))
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

        // POST: api/GuestInvoices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GuestInvoice>> PostGuestInvoice(GuestInvoice guestInvoice)
        {
          if (_context.Invoices == null)
          {
              return Problem("Entity set 'HotelDbContext.Invoices'  is null.");
          }
            _context.Invoices.Add(guestInvoice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGuestInvoice", new { id = guestInvoice.InvoiceId }, guestInvoice);
        }

        // DELETE: api/GuestInvoices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuestInvoice(int id)
        {
            if (_context.Invoices == null)
            {
                return NotFound();
            }
            var guestInvoice = await _context.Invoices.FindAsync(id);
            if (guestInvoice == null)
            {
                return NotFound();
            }

            _context.Invoices.Remove(guestInvoice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GuestInvoiceExists(int id)
        {
            return (_context.Invoices?.Any(e => e.InvoiceId == id)).GetValueOrDefault();
        }
    }
}
