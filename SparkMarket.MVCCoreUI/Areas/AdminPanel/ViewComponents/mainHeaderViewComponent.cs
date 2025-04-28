using Microsoft.AspNetCore.Mvc;

namespace SparkMarket.MVCCoreUI.Areas.AdminPanel.ViewComponents
{
    public class mainHeaderViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
