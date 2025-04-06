using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUı.ViewComponents.LayoutComponents
{
    public class _LayoutScriptComponentPartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }   
    }
}
