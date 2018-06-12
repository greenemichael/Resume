using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Education : Experience 
    {
        [MaxLength(25)]
        public string Degree {get; set;}
    }
}