using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Education : Experience 
    {
        [MaxLength(25)]
        public string Degree {get; set;}
    }
}