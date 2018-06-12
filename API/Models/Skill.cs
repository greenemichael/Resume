using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace API.Models
{
    public class Skill
    {
        public int ID {get; set;}

        [MaxLength(25)]
        public string Name {get; set;}
        
        [MaxLength(200)]
        public string Description {get; set;}
    }
}