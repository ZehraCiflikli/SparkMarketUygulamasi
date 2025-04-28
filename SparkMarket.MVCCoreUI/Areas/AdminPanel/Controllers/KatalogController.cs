using Microsoft.AspNetCore.Mvc;
using SparkMarket.Business.Abstract;
using SparkMarket.MVCCoreUI.Filters;

namespace SparkMarket.MVCCoreUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class KatalogController : Controller
    {

     

        [MenuFilter]

        [RolFilter("Admin", "Muahasebe")]

        public IActionResult Kategori()
        {
            return View();
        }
    }
}
