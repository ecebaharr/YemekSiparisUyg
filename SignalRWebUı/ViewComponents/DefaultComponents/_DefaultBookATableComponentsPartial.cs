using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace SignalRWebUı.ViewComponents.DefaultComponents
{
    public class _DefaultBookATableComponentsPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(); // Veya View(model);
        }

    }
   
}
