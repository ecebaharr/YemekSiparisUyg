using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUı.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult NotFound404Page()
        {
            return View();
        }
    }
}
