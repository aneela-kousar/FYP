using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskBoss.Models;
using TaskBossApi.Models;

namespace TaskBossApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly TaskBossContext _context;

        public ProfileController(TaskBossContext context)
        {
            _context = context;
        }

        // GET: api/Profile
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profile>>> GetProfiles()
        {
            return await _context.Profiles.ToListAsync();
        }

        // GET: api/Profile/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Profile>> GetProfileById(int id)
        {
            var Profile = await _context.Profiles.FindAsync(id);

            if (Profile == null)
            {
                return NotFound();
            }

            return Profile;
        }

        // PUT: api/Profile/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfile(int id, Profile Profile)
        {
            if (id != Profile.Id)
            {
                return BadRequest();
            }

            _context.Entry(Profile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfileExists(id))
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

        // POST: api/Profile
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Profile>> PostProfile(Profile Profile)
        {
            _context.Profiles.Add(Profile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfile", new { id = Profile.Id }, Profile);
        }

        // DELETE: api/Profile/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfile(int id)
        {
            var Profile = await _context.Profiles.FindAsync(id);
            if (Profile == null)
            {
                return NotFound();
            }

            _context.Profiles.Remove(Profile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfileExists(int id)
        {
            return _context.Profiles.Any(e => e.Id == id);
        }
    }
}
