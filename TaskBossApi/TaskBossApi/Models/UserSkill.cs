using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskBossApi.Models
{
    public class UserSkill
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        [Column(TypeName = "int")]
        public int UserId { get; set; }

        [ForeignKey("Skill")]
        [Column(TypeName = "int")]
        public int SkillId { get; set; }

        [Column(TypeName = "int")]
        public int SkillLevel { get; set; }
    }
}
