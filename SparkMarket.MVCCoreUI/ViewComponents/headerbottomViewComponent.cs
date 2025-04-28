using Microsoft.AspNetCore.Mvc;

namespace SparkMarket.MVCCoreUI.ViewComponents
{
	public class headerbottomViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();

		}
	
	}
}
