using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUı.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
