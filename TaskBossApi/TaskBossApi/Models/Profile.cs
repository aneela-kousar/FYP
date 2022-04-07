using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskBossApi.Models
{
    public class Profile
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(300)")]
        public string UserName { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string UserClass { get; set; }

        [ForeignKey("Domain")]
        [Column(TypeName = "int")]
        public int DomainId { get; set; }

        [NotMapped]
        public string DomainName { get; set; }

    }
}
