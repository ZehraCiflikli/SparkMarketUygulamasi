using Microsoft.AspNetCore.Mvc;

namespace SparkMarket.MVCCoreUI.ViewComponents
{
	public class headertopViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();

		}
	
	}
}
