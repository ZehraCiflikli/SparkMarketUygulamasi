using Microsoft.AspNetCore.Mvc;

namespace SparkMarket.MVCCoreUI.ViewComponents
{
	public class footerViewComponent:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();	

		}
	}
}
