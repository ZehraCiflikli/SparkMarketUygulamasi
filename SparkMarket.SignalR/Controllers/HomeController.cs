using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SparkMarket.SignalR.Models;
using System.Diagnostics;

namespace SparkMarket.SignalR.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHubContext<MarketHub> _context;

        public HomeController(ILogger<HomeController> logger, IHubContext<MarketHub> context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            // HUB classý dýþýnda da clienttaki connection üzerindeki ReceiveMessage metodu tetiklendi


            _context.Clients.All.SendAsync("ReceiveMessage", "", "");


            _context.Clients.User("1").SendAsync("ReceiveMessage", "", ""); // Tek bir kullanýcýya gerçek zamanlý olarak ReceiveMessage metodunu tetiklemek istersen bu yapýyý kullanabilirsin..


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
