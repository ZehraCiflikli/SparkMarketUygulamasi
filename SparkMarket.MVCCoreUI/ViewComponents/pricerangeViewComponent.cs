﻿using Microsoft.AspNetCore.Mvc;

namespace SparkMarket.MVCCoreUI.ViewComponents
{
	public class pricerangeViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();

		}
	}
}
