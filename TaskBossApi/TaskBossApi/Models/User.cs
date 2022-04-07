using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskBossApi.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Column(TypeName = "nvarchar(300)")]
        public string UserName { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string UserType { get; set; }

        [Column(TypeName = "nvarchar(300)")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(300)")]
        public string Password { get; set; }

        [ForeignKey("Domain")]
        [Column(TypeName = "int")]
        public int DomainId { get; set; }

        [ForeignKey("SubDomain")]
        [Column(TypeName = "int")]
        public int SubDomainId { get; set; }
    }
}
