using BestStoreMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace BestStoreMVC.Controllers
{
    public class CustomersController : Controller
    {
        public readonly ApplicationDbContext applicationDbContext;
        public CustomersController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public IActionResult Index()
        {
            var customers = applicationDbContext.Customers.ToList();
            return View(customers);
        }

       
    }
}
