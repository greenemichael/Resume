using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class APIConnection
    {
        [MaxLength(30)]
        public string BaseURL {get; set;}
    }
}