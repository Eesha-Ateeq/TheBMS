using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Required]
        public int Price { get; set; }

        [ForeignKey("BakeryBaker")]
        public int BakerID { get; set; }
        public virtual Baker BakeryBaker { get; set; }

       


    }
}
