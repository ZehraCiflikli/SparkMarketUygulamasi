using Microsoft.AspNetCore.Mvc;

namespace SparkMarket.MVCCoreUI.ViewComponents
{
	public class headermiddleViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();

		}
	
	}
}
