using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Activity : Experience 
    {
        [MaxLength(50)]
        public string Group {get; set;}
    }
}