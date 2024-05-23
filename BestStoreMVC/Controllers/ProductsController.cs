using BestStoreMVC.Models;
using BestStoreMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace BestStoreMVC.Controllers
{
    public class ProductsController : Controller
    {
        public readonly ApplicationDbContext applicationDbContext;
        public ProductsController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public IActionResult Index()
        {
            var products = applicationDbContext.Products.ToList();
            return View(products);
        }

       
    }
}
