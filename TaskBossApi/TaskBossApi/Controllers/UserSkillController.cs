using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskBossApi.Models;

namespace TaskBossApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSkillController : ControllerBase
    {
        private readonly TaskBossContext _context;

        public UserSkillController(TaskBossContext context)
        {
            _context = context;
        }

        // GET: api/UserSkill
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserSkill>>> GetUserSkills()
        {
            return await _context.UserSkills.ToListAsync();
        }

        // GET: api/UserSkill/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserSkill>> GetUserSkill(int id)
        {
            var userSkill = await _context.UserSkills.FindAsync(id);

            if (userSkill == null)
            {
                return NotFound();
            }

            return userSkill;
        }

        // PUT: api/UserSkill/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserSkill(int id, UserSkill userSkill)
        {
            if (id != userSkill.Id)
            {
                return BadRequest();
            }

            _context.Entry(userSkill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserSkillExists(id))
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

        // POST: api/UserSkill
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserSkill>> PostUserSkill(UserSkill userSkill)
        {
            _context.UserSkills.Add(userSkill);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserSkill", new { id = userSkill.Id }, userSkill);
        }

        // DELETE: api/UserSkill/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserSkill(int id)
        {
            var userSkill = await _context.UserSkills.FindAsync(id);
            if (userSkill == null)
            {
                return NotFound();
            }

            _context.UserSkills.Remove(userSkill);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserSkillExists(int id)
        {
            return _context.UserSkills.Any(e => e.Id == id);
        }
    }
}
