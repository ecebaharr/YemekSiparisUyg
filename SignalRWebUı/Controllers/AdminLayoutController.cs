using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUı.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
