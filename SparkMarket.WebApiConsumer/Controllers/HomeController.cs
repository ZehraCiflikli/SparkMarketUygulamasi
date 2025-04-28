using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SparkMarket.WebApiConsumer.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace SparkMarket.WebApiConsumer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        // api/Kategori
        // Get
        public async Task<IActionResult> Index()
        {

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("username", "admin");
            client.DefaultRequestHeaders.Add("password", "12345");
            var response = await client.GetAsync("http://localhost:5146/api/Kategori/");
            ApiResponse<List<KategoriDTO>> api = new ApiResponse<List<KategoriDTO>>();
            if (response.IsSuccessStatusCode)
            {

                var result = response.Content.ReadAsStringAsync().Result;
                api = JsonConvert.DeserializeObject<ApiResponse<List<KategoriDTO>>>(result);
            }
            HomeIndexViewModel model = new HomeIndexViewModel();
            model.Data = api.Data;
            return View(model);
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

        public IActionResult KategoriEkle()
        {
            KategoriDTO dTO = new KategoriDTO();


            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("username", "admin");
            client.DefaultRequestHeaders.Add("password", "12345");
            var response =  client.GetAsync("http://localhost:5146/api/Kategori/").Result;
            ApiResponse<List<KategoriDTO>> api = new ApiResponse<List<KategoriDTO>>();
            if (response.IsSuccessStatusCode)
            {

                var result = response.Content.ReadAsStringAsync().Result;
                api = JsonConvert.DeserializeObject<ApiResponse<List<KategoriDTO>>>(result);
            }
            dTO.KategoriList = api.Data.Select(x=>new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
            {
                 Text=x.UstKategoriGorunum,
                 Value=x.Id.ToString()

            }).ToList();




            return View(dTO);

        }


        // api/Kategori
        // Post

        [HttpPost]
        public IActionResult KategoriEkle(KategoriDTO dto)
        {
            // Proje Yayýnlama
            // Solid Prensipleri
            // SignalR
            // Proje Rapor Ýndirme
            // ---


            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("username", "admin");
            client.DefaultRequestHeaders.Add("password", "12345");
            string json = JsonConvert.SerializeObject(dto);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage result = client.PostAsync("http://localhost:5146/api/Kategori/", content).Result;

            TempData["mesaj"] = result.Content.ReadAsStringAsync().Result;


            return View();

        }

        [HttpPost]
        public IActionResult KategoriGuncelle(KategoriDTO dto)
        {
            // KategoriDTO dolu bir id olmallý 
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("username", "admin");
            client.DefaultRequestHeaders.Add("password", "12345");
            string json = JsonConvert.SerializeObject(dto);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage result = client.PutAsync("http://localhost:5146/api/Kategori/", content).Result;

            TempData["mesaj"] = result.Content.ReadAsStringAsync().Result;


            return View();

        }

        [HttpPost]
        public IActionResult KategoriSil(int KatId)
        {

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("username", "admin");
            client.DefaultRequestHeaders.Add("password", "12345");

            HttpResponseMessage result = client.DeleteAsync("http://localhost:5146/api/Kategori/" + KatId).Result;

            TempData["mesaj"] = result.Content.ReadAsStringAsync().Result;


            return View();

        }
    }
}
