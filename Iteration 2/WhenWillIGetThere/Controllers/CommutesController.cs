﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WhenWillIGetThere.Models;
using WhenWillIGetThere.Data;

namespace WhenWillIGetThere.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommutesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CommutesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Commutes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Commutes>>> GetCommutes()
        {
            // :D --> SELECT c.* FROM Commutes c JOIN Routes r ON r.Id = c.RouteId WHERE r.UserId = @userid
            return await _context.Routes
                            .Where(r => r.UserId == this.CurrentUserId())
                            .Join(_context.Commutes,
                                  r => r.Id,
                                  c => c.Route.Id,
                                  (r, c) => c)
                            .ToListAsync();
        }

        // GET: api/Commutes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Commutes>> GetCommutes(int id)
        {
            var commutes = await _context.Commutes
                                    .Where(c => c.Id == id)
                                    .Join(_context.Routes,
                                          c => c.Route.Id,
                                          r => r.Id,
                                          (c, r) => c)
                                    .ToListAsync();

            if (commutes == null)
            {
                return NotFound();
            }
            if (commutes.Count > 0)
            {
                return BadRequest();
            }

            return commutes.FirstOrDefault();
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

            var route = await _context.Routes.FindAsync(commutes.RouteId);
            if(route.UserId != this.CurrentUserId())
            {
                return Unauthorized();
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

            var route = await _context.Routes.FindAsync(commutes.RouteId);
            if (route.UserId != this.CurrentUserId())
            {
                return Unauthorized();
            }

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
            var route = await _context.Routes.FindAsync(commutes.RouteId);
            if (route.UserId != this.CurrentUserId())
            {
                return Unauthorized();
            }

            _context.Commutes.Remove(commutes);
            await _context.SaveChangesAsync();

            return commutes;
        }

        private bool CommutesExists(int id)
        {
            return _context.Commutes
                            .Where(c => c.Id == id)
                            .Join(_context.Routes,
                                    c => c.Route.Id,
                                    r => r.Id,
                                    (c, r) => c)
                            .Any();
        }
    }
}
