using BestStoreMVC.Models;
using BestStoreMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace BestStoreMVC.Controllers
{
    public class ProfileController : Controller
    {private long loggedInId=1;
        public readonly ApplicationDbContext applicationDbContext;
        public ProfileController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public IActionResult Index()
        {
            var profile = applicationDbContext.Customers.ToList().FirstOrDefault(c=>c.Id== loggedInId);

            return View(profile);
        }
       

    }
}
