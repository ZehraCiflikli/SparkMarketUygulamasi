using Microsoft.AspNetCore.Mvc;

namespace SparkMarket.MVCCoreUI.ViewComponents
{
	public class brandViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();

		}
	
	}
}
