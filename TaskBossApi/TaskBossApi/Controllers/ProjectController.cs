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
    public class ProjectController : ControllerBase
    {
        private readonly TaskBossContext _context;

        public ProjectController(TaskBossContext context)
        {
            _context = context;
        }

        // GET: api/Project
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {
            return await _context.Projects.ToListAsync();
        }

        // GET: api/Project/domainId/subDomainId/pageId
        [HttpGet("{domainId}/{subDomainId}/{pageId}")]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjectsBySubDomain(int domainId, int subDomainId, int pageId)
        {
            var projList = new List<Project>();

            if (pageId == 0)
            {
                projList = await _context.Projects.Where(x => 
                (
                    x.DomainId == domainId &&
                    x.SubDomainId == subDomainId &&
                    x.IsCompleted == false &&
                    x.IsAssigned == false
                )).ToListAsync();
            }
            else if(pageId == 1)
            {
                projList = await _context.Projects.Where(x => 
                (
                x.DomainId == domainId &&
                x.SubDomainId == subDomainId &&
                x.IsCompleted == true && 
                (x.IsAssigned == false || (x.IsAssigned == true && x.IsPaid == true)) 
                )).ToListAsync();
            }
            return projList;
        }

        // GET: api/Project/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);

            if (project == null)
            {
                return NotFound();
            }
            var domain = await _context.Domains.FindAsync(project.DomainId);
            project.DomainName = domain.DomainName;
            var subDomain = await _context.SubDomains.FindAsync(project.SubDomainId);
            project.SubDomainName = subDomain.SubDomainName;

            return project;
        }

        // PUT: api/Project/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(int id, Project project)
        {
            if (id != project.ProjectId)
            {
                return BadRequest();
            }

            _context.Entry(project).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
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

        // POST: api/Project
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Project>> PostProject(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProject", new { id = project.ProjectId }, project);
        }

        // DELETE: api/Project/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.ProjectId == id);
        }
    }
}
