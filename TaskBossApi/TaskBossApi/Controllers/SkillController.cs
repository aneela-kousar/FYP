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
    public class SkillController : ControllerBase
    {
        private readonly TaskBossContext _context;

        public SkillController(TaskBossContext context)
        {
            _context = context;
        }

        // GET: api/Skill
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Skills>>> GetSkills()
        {
            return await _context.Skills.ToListAsync();
        }

        // GET: api/Skill/UserId
        [HttpGet("{userId:int}")]
        public async Task<ActionResult<IEnumerable<Skills>>> GetSkillsByUserId(int userId)
        {
            return await _context.Skills.Where(x => x.UserId == userId).ToListAsync();
        }

        // GET: api/Skill/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Skills>> GetSkills(int id)
        {
            var skills = await _context.Skills.FindAsync(id);

            if (skills == null)
            {
                return NotFound();
            }

            return skills;
        }

        // PUT: api/Skill/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSkills(int id, Skills skills)
        {
            if (id != skills.SkillId)
            {
                return BadRequest();
            }

            _context.Entry(skills).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkillsExists(id))
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

        // POST: api/Skill
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Skills>> PostSkills(Skills skills)
        {
            _context.Skills.Add(skills);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSkills", new { id = skills.SkillId }, skills);
        }

        // DELETE: api/Skill/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkills(int id)
        {
            var skills = await _context.Skills.FindAsync(id);
            if (skills == null)
            {
                return NotFound();
            }

            _context.Skills.Remove(skills);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SkillsExists(int id)
        {
            return _context.Skills.Any(e => e.SkillId == id);
        }
    }
}
