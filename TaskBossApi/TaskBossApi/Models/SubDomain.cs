using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TaskBoss.Models;

namespace TaskBossApi.Models
{
    public class SubDomain
    {
        [Key]
        public int SubDomainId { get; set; }

        [Column(TypeName = "nvarchar(300)")]
        public string SubDomainName { get; set; }

        [ForeignKey("Domain")]
        [Column(TypeName = "int")]
        public int DomainId { get; set; }

    }
}
