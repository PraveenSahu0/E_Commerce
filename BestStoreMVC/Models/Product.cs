using System.ComponentModel.DataAnnotations;

namespace BestStoreMVC.Models
{
    public class Product
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string Category { get; set; }  = "";  
        public decimal Price { get; set; }
        public string ImageFileName { get; set; } = "";
        public DateTime CreatedAt { get; set; }
                
    }
}
