using Microsoft.AspNetCore.Mvc;

namespace SuperMarket.Controllers
{
    public class CustomersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
