using Microsoft.AspNetCore.Mvc;
using SparkMarket.SoapUI.Calculator.Models;
using System.Diagnostics;

namespace SparkMarket.SoapUI.Calculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            // SOAP SERVÝSLERÝ
            // -- BÝR ENVOLOPE ZARH YAPISINDA KULLANABÝLÝRSÝNÝZ
            // -- HttpClient aracýlýðýyla



            ServiceReferenceCalculator.CalculatorSoapClient.EndpointConfiguration configuration = new ServiceReferenceCalculator.CalculatorSoapClient.EndpointConfiguration();
           

            ServiceReferenceCalculator.CalculatorSoapClient client = new ServiceReferenceCalculator.CalculatorSoapClient(configuration, "http://www.dneonline.com/calculator.asmx?WSDL");


            int TOPLAM = await client.AddAsync(5, 25);


            //--------------------------------------------------------------

            // DivideRequest req = new DivideRequest();
            // req.Userid=5;
            // req.il = "ANKARA";


          //  int sonuc = await client.DivideAsync(req);
          //  DivideResponse sonuc = await client.DivideAsync(req);
      

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
