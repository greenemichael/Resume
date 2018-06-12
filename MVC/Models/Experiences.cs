using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace MVC.Models
{
    public class Experience
    {
        [Key] // do this to tell Education to use ID as primary key
        public int ID {get; set;} // make {convention: ID=primary key} for child class clarity
        
        [MaxLength(50)]
        public string Institution {get; set;}

        [MaxLength(50)]
        public string Title {get; set;}

        public DateTime Start {get; set;}

        public DateTime? End {get; set;}

        public virtual ICollection<Task> Tasks {get; set;}
    }
}