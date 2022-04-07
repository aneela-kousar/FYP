using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TaskBossApi.Models;

namespace TaskBoss.Models
{
    public class Domain
    {
        [Key]
        public int DomainId { get; set; }

        [Column(TypeName="nvarchar(100)")]
        public string DomainName { get; set; }

        //public ICollection<SubDomain> SubDomains { get; set; }
    }
}
