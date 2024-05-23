using BestStoreMVC.Models;
using BestStoreMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace BestStoreMVC.Controllers
{
    public class OrdersController : Controller
    {
        private long loggedInCustomerId = 1;

        public readonly ApplicationDbContext applicationDbContext;
        public OrdersController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public IActionResult Index()
        {
            var orders = applicationDbContext.Orders.OrderByDescending(o => o.OrderDate).ToList();
            return View(orders);
        }

        [HttpPost]
        public IActionResult PlaceOrder(List<OrderDetail> orderItems)
        {
            if (orderItems.Count>0)
            {
              
                var order = new Order
                {
                    OrderDetails = orderItems.Where(o=>o.Quantity > 0).ToList(),
                };

                PlaceOrder(order);
                return RedirectToAction("OrderConfirmation");
            }
            return RedirectToAction("Index");

        }
        public IActionResult OrderConfirmation()
        {
            return View();
        }
        [HttpGet]
        public IActionResult OrderDetails(long Id)
        {
            try
            {
                var orderDetails = applicationDbContext.VwOrderDetails.Where(od => od.OrderId == Id).ToList();
                return View(orderDetails);

            }
            catch (Exception)
            {

                throw;
            }
        }
   
        public void PlaceOrder(Order order)
        {
            order.CustomerId = loggedInCustomerId;
            order.OrderDate = DateTime.Now;
            applicationDbContext.Orders.Add(order);
            foreach (var orderDetail in order.OrderDetails)
            {
                orderDetail.Id = 0; 
                orderDetail.OrderId = order.Id;
                applicationDbContext.OrderDetails.Add(orderDetail);
            }
            applicationDbContext.SaveChanges();
        }


    }
}
