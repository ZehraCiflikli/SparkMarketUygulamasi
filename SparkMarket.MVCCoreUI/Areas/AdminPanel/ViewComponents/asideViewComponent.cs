using Microsoft.AspNetCore.Mvc;

namespace SparkMarket.MVCCoreUI.Areas.AdminPanel.ViewComponents
{
    public class asideViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
