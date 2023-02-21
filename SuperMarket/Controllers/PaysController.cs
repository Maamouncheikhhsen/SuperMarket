using Microsoft.AspNetCore.Mvc;

namespace SuperMarket.Controllers
{
    public class PaysController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
