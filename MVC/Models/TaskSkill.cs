using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public class TaskSkill
    {
        public int ID  {get; set;}
        
        [ForeignKey("Task")]
        public int TaskID {get; set;}
        
        [ForeignKey("Skill")]
        public int SkillID {get; set;}

        public virtual Task Task {get; set;}
        public virtual Skill Skill {get; set;}
    }
}