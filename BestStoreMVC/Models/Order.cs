namespace BestStoreMVC.Models
{
    public class Order
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
