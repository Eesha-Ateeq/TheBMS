using System.ComponentModel.DataAnnotations;

namespace TheBMS.Models
{
    public class Baker
    {
        [key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
