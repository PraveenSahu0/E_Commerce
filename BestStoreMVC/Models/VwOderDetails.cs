using System.ComponentModel.DataAnnotations.Schema;

namespace BestStoreMVC.Models
{
    [Table("VwOderDetails")]
    public class VwOderDetails
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public string Name { get; set; } = "";
        public string ImageFileName { get; set; } = "";
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
