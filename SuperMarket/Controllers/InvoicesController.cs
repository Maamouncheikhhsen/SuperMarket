using Microsoft.AspNetCore.Mvc;

namespace SuperMarket.Controllers
{
    public class InvoicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
