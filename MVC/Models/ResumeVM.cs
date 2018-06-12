using System.Collections.Generic;

namespace MVC.Models
{
    public class ResumeVM
    {
        public ICollection<Experience> Experiences {get; set;}
        public ICollection<Education> Education {get; set;}
        public ICollection<Activity> Activities {get; set;}
        public ICollection<Skill> Skills {get; set;}
    }
}