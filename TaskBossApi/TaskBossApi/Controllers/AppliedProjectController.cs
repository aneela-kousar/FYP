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
    public class AppliedProjectController : ControllerBase
    {
        private readonly TaskBossContext _context;

        public AppliedProjectController(TaskBossContext context)
        {
            _context = context;
        }

        // GET: api/AppliedProject
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppliedProject>>> GetAppliedProjects()
        {
            return await _context.AppliedProjects.ToListAsync();
        }

        // GET: api/AppliedProject/userId/notifType
        [HttpGet("{userId}/{notifType}")]
        public async Task<ActionResult<IEnumerable<AppliedProject>>> GetProjectsById(int userId, int notifType)
        {
            if(notifType == 1)
            {

            }
            return await _context.AppliedProjects.Where(x => (x.OwnerId == userId || x.ApplierId==userId)).ToListAsync();
        }


        // GET: api/AppliedProject/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppliedProject>> GetAppliedProject(int id)
        {
            var AppliedProject = await _context.AppliedProjects.FindAsync(id);

            if (AppliedProject == null)
            {
                return NotFound();
            }

            return AppliedProject;
        }

        // PUT: api/AppliedProject/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppliedProject(int id, AppliedProject AppliedProject)
        {
            if (id != AppliedProject.Id)
            {
                return BadRequest();
            }

            _context.Entry(AppliedProject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppliedProjectExists(id))
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

        // POST: api/AppliedProject
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Models.AppliedProject>> PostAppliedProject(AppliedProject AppliedProject)
        {
            _context.AppliedProjects.Add(AppliedProject);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppliedProject", new { id = AppliedProject.Id }, AppliedProject);
        }

        // DELETE: api/AppliedProject/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppliedProject(int id)
        {
            var AppliedProject = await _context.AppliedProjects.FindAsync(id);
            if (AppliedProject == null)
            {
                return NotFound();
            }

            _context.AppliedProjects.Remove(AppliedProject);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppliedProjectExists(int id)
        {
            return _context.AppliedProjects.Any(e => e.Id == id);
        }
    }
}
