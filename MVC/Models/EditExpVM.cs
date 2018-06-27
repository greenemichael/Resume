using System.Collections.Generic;

namespace MVC.Models
{
    public class EditExpVM
    {
        public virtual Experience Experience {get; set;}

        public ICollection<Skill> Skills {get; set;}
    }
}