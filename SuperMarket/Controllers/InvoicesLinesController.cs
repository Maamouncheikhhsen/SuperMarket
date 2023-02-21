using Microsoft.AspNetCore.Mvc;

namespace SuperMarket.Controllers
{
    public class InvoicesLinesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
