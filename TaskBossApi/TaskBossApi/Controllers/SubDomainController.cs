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
    public class SubDomainController : ControllerBase
    {
        private readonly TaskBossContext _context;

        public SubDomainController(TaskBossContext context)
        {
            _context = context;
        }

        // GET: api/SubDomain/domainId
        [HttpGet("{domainId:int}")]
        public async Task<ActionResult<IEnumerable<SubDomain>>> GetSubDomains(int domainId)
        {
            return await _context.SubDomains.Where(x => x.DomainId == domainId).ToListAsync();
        }

        // GET: api/SubDomain/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<SubDomain>> GetSubDomain(int id)
        //{
        //    var subDomain = await _context.SubDomains.FindAsync(id);

        //    if (subDomain == null)
        //    {
        //        return NotFound();
        //    }

        //    return subDomain;
        //}

        // PUT: api/SubDomain/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutSubDomain(int id, SubDomain subDomain)
        //{
        //    if (id != subDomain.SubDomainId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(subDomain).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!SubDomainExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/SubDomain
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SubDomain>> PostSubDomain(SubDomain subDomain)
        {
            _context.SubDomains.Add(subDomain);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubDomain", new { id = subDomain.SubDomainId }, subDomain);
        }

        // DELETE: api/SubDomain/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteSubDomain(int id)
        //{
        //    var subDomain = await _context.SubDomains.FindAsync(id);
        //    if (subDomain == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.SubDomains.Remove(subDomain);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool SubDomainExists(int id)
        //{
        //    return _context.SubDomains.Any(e => e.SubDomainId == id);
        //}
    }
}
