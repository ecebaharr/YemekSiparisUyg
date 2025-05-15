using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUı.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CLientUserCount()
        {
            return View();
        }
    }
}
