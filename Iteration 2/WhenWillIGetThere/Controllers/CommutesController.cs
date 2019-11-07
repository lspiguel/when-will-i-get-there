using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WhenWillIGetThere.Models;

namespace WhenWillIGetThere.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommutesController : ControllerBase
    {
        private readonly aspnetWhenWillIGetThereContext _context;

        public CommutesController(aspnetWhenWillIGetThereContext context)
        {
            _context = context;
        }

        // GET: api/Commutes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Commutes>>> GetCommutes()
        {
            return await _context.Commutes.ToListAsync();
        }

        // GET: api/Commutes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Commutes>> GetCommutes(int id)
        {
            var commutes = await _context.Commutes.FindAsync(id);

            if (commutes == null)
            {
                return NotFound();
            }

            return commutes;
        }

        // PUT: api/Commutes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommutes(int id, Commutes commutes)
        {
            if (id != commutes.Id)
            {
                return BadRequest();
            }

            _context.Entry(commutes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommutesExists(id))
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

        // POST: api/Commutes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Commutes>> PostCommutes(Commutes commutes)
        {
            _context.Commutes.Add(commutes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommutes", new { id = commutes.Id }, commutes);
        }

        // DELETE: api/Commutes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Commutes>> DeleteCommutes(int id)
        {
            var commutes = await _context.Commutes.FindAsync(id);
            if (commutes == null)
            {
                return NotFound();
            }

            _context.Commutes.Remove(commutes);
            await _context.SaveChangesAsync();

            return commutes;
        }

        private bool CommutesExists(int id)
        {
            return _context.Commutes.Any(e => e.Id == id);
        }
    }
}
