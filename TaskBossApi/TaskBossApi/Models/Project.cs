using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskBossApi.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        [Column(TypeName = "nvarchar(300)")]
        public string Description { get; set; }

        [Column(TypeName = "int")]
        public int Budget { get; set; }

        [Column(TypeName = "int")]
        public int TimeRequired { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string Skill { get; set; }

        [Column(TypeName = "bit")]
        public bool IsAssigned { get; set; }
        
        [Column(TypeName = "bit")]
        public bool IsCompleted { get; set; }

        [Column(TypeName = "bit")]
        public bool IsPaid { get; set; }

        [ForeignKey("Domain")]
        [Column(TypeName = "int")]
        public int DomainId { get; set; }

        [NotMapped]
        public string DomainName { get; set; }

        [ForeignKey("SubDomain")]
        [Column(TypeName = "int")]
        public int SubDomainId { get; set; }

        [NotMapped]
        public string SubDomainName { get; set; }

        [ForeignKey("User")]
        [Column(TypeName = "int")]
        public int OwnerId { get; set; }

        [NotMapped]
        public string OwnerName { get; set; }

        [Column(TypeName = "int")]
        public int OwnerType { get; set; }

        [ForeignKey("User")]
        [Column(TypeName = "int")]
        public int FreelancerId { get; set; }
    }
}
