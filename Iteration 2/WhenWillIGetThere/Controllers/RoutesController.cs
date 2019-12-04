using System;
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
    public class RoutesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RoutesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Routes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Routes>>> GetRoutes()
        {
            return await _context.Routes.Where(r => r.UserId == this.CurrentUserId()).ToListAsync();
        }

        // GET: api/Routes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Routes>> GetRoutes(int id)
        {
            var routes = await _context.Routes.FindAsync(id);

            if (routes == null)
            {
                return NotFound();
            }
            else if (routes.UserId != this.CurrentUserId())
            {
                return Unauthorized();
            }

            return routes;
        }

        // PUT: api/Routes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoutes(int id, Routes route)
        {
            if (id != route.Id)
            {
                return BadRequest();
            }

            if (route.UserId != this.CurrentUserId())
            {
                return Unauthorized();
            }

            _context.Entry(route).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoutesExists(id))
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

        // POST: api/Routes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Routes>> PostRoutes(Routes routes)
        {
            if (routes.UserId != this.CurrentUserId())
            {
                return Unauthorized();
            }

            _context.Routes.Add(routes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoutes", new { id = routes.Id }, routes);
        }

        // DELETE: api/Routes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Routes>> DeleteRoutes(int id)
        {
            var routes = await _context.Routes.FindAsync(id);
            if (routes == null)
            {
                return NotFound();
            }
            if (routes.UserId != this.CurrentUserId())
            {
                return Unauthorized();
            }

            _context.Routes.Remove(routes);
            await _context.SaveChangesAsync();

            return routes;
        }

        private bool RoutesExists(int id)
        {
            return _context.Routes.Any(e => e.Id == id && e.UserId == this.CurrentUserId());
        }
    }
}
