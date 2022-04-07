using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskBossApi.Models
{
    public class AppliedProject
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "bit")]
        public bool IsChecked { get; set; }
        
        [Column(TypeName = "bit")]
        public bool IsApproved { get; set; }

        [ForeignKey("Project")]
        [Column(TypeName = "int")]
        public int ProjectId { get; set; }

        [Column(TypeName = "nvarchar(300)")]
        public string ProjectDescription { get; set; }

        [ForeignKey("User")]
        [Column(TypeName = "int")]
        public int OwnerId { get; set; }

        [ForeignKey("User")]
        [Column(TypeName = "int")]
        public int ApplierId { get; set; }
    }
}
