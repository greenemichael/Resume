using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace API.Models
{
    public class Task
    {
        public int ID {get; set;}

        [MaxLength(200)]
        public string Description {get; set;}

        public virtual ICollection<TaskSkill> TSlist {get; set;}

        [ForeignKey("Experience")]
        public int ExperienceID {get; set;}
        public virtual Experience Experience {get; set;}
    }
}