using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUı.ViewComponents.LayoutComponents;

public class _LayoutNavbarComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
