using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskBoss.Models;
using TaskBossApi.Models;

namespace TaskBossApi.Models
{
    public class TaskBossContext:DbContext
    {
        public TaskBossContext(DbContextOptions<TaskBossContext> options):base(options)
        {

        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Domain> Domains { get; set; }
        public virtual DbSet<SubDomain> SubDomains { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Skills> Skills { get; set; }
        public virtual DbSet<UserSkill> UserSkills { get; set; }
        public virtual DbSet<AppliedProject> AppliedProjects { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
    }
}
