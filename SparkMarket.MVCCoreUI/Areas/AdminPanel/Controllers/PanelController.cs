using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SparkMarket.Business.Common;
using SparkMarket.Model.Entity;
using SparkMarket.MVCCoreUI.Filters;

namespace SparkMarket.MVCCoreUI.Areas.AdminPanel.Controllers
{

    [Area("AdminPanel")]
    [YoneticiFilter]
    public class PanelController : Controller
    {

        IMemoryCache _cache;
        public PanelController(IMemoryCache cache)
        {
            _cache = cache;
        }

        public IActionResult Index()
        {
            //int sonuc;
            //bool b = int.TryParse("dfgdfg", out sonuc);
            //if (b)
            //{
            //    int k = sonuc * 2;

            //}

            //string isim = _cache.Get<string>("isim");


            //Kullanici k = _cache.Get<Kullanici>("Aktif");
            //string isim2;
            //bool b = _cache.TryGetValue("isim", out isim2);
            //if (b)
            //{
            //    int sayi = isim2.Length;
            //}

            //  Kategori k = RedisOpearations.GetObjectRedisCache<Kategori>("Kat");


            return View();
        }
    }
}
