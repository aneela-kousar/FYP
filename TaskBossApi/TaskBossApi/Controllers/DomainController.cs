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
    public class DomainController : ControllerBase
    {
        private readonly TaskBossContext _context;

        public DomainController(TaskBossContext context)
        {
            _context = context;
        }

        // GET: api/Domain
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Domain>>> GetDomains()
        {
            return await _context.Domains.ToListAsync();
        }

        // GET: api/Domain/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Domain>> GetDomain(int id)
        {
            var domain = await _context.Domains.FindAsync(id);

            if (domain == null)
            {
                return NotFound();
            }

            return domain;
        }

        // PUT: api/Domain/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDomain(int id, Domain domain)
        {
            if (id != domain.DomainId)
            {
                return BadRequest();
            }

            _context.Entry(domain).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DomainExists(id))
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

        // POST: api/Domain
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Domain>> PostDomain(Domain domain)
        {
            _context.Domains.Add(domain);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDomain", new { id = domain.DomainId }, domain);
        }

        // DELETE: api/Domain/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDomain(int id)
        {
            var domain = await _context.Domains.FindAsync(id);
            if (domain == null)
            {
                return NotFound();
            }

            _context.Domains.Remove(domain);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DomainExists(int id)
        {
            return _context.Domains.Any(e => e.DomainId == id);
        }
    }
}
