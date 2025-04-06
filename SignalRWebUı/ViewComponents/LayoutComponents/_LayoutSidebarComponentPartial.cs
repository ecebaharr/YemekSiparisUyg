using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUı.ViewComponents.LayoutComponents
{
    public class _LayoutSidebarComponentPartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }   
    }
}
