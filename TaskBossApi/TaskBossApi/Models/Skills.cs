using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskBossApi.Models
{
    public class Skills
    {
        [Key]
        public int SkillId { get; set; }

        [Column(TypeName = "nvarchar(300)")]
        public string SkillName { get; set; }

        [Column(TypeName = "int")]
        public int SkillLevel { get; set; }

        [ForeignKey("User")]
        [Column(TypeName = "int")]
        public int UserId { get; set; }
    }
}
