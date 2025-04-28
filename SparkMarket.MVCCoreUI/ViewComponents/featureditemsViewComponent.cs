using Microsoft.AspNetCore.Mvc;

namespace SparkMarket.MVCCoreUI.ViewComponents
{
    public class featureditemsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        }
    }
}
