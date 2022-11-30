using System.ComponentModel.DataAnnotations;

namespace TheBMS.Models
{
    public class bakerymenu
    {
        [key]
        public int Id { get; set; }  

        [Required]
        public string Title { get; set; }  
        
        [Required]
        public string URL { get; set; }
    }
}
