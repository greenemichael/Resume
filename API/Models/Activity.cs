using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Activity : Experience
    {
        [MaxLength(50)]
        public string Group {get; set;}
    }
}