using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUı.ViewComponents.LayoutComponents
{
    public class _LayoutFooterComponentPartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }   
    }
}
