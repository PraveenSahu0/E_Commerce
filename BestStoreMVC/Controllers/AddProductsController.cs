using BestStoreMVC.Models;
using BestStoreMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace BestStoreMVC.Controllers
{
    public class AddProductsController : Controller
    {
        public readonly ApplicationDbContext applicationDbContext;
        public AddProductsController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public IActionResult Index()
        {
            var products = applicationDbContext.Products.ToList();
            return View(products);
        }

        public IActionResult AddNewProductPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InsertNewProduct(Product product)
        {
            applicationDbContext.Products.Add(product);
            applicationDbContext.SaveChanges();
            return RedirectToAction("Index", "Products");
        }
      
        [HttpPut]
        public IActionResult EditProduct(Product product)
        {
            applicationDbContext.Products.Update(product);
            applicationDbContext.SaveChanges();
            return RedirectToAction("Index", "Products");
        }
        [HttpDelete,HttpGet]
        public IActionResult DeleteProduct(long id)
        {
            var product = applicationDbContext.Products.Find(id);
            applicationDbContext.Products.Remove(product);
            applicationDbContext.SaveChanges();
            return RedirectToAction("Index", "Products");
        }
    }
}
