using Infrastructure.CrossCuttingConcern.Converters;
using Infrastructure.CrossCuttingConcern.Crypto;
using Microsoft.AspNetCore.Mvc;
using SparkMarket.Business.Abstract;
using SparkMarket.Model.Entity;
using SparkMarket.Model.ViewModel;
using SparkMarket.Model.ViewModel.Areas.AdminPanel;
using SparkMarket.MVCCoreUI.Filters;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;
using Infrastructure.Utility;
using SparkMarket.Business.Concrete.Base;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;


namespace SparkMarket.MVCCoreUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class YoneticiController : Controller
    {
        // Validation 
        // Güvenlik Kodu
        // 
        private readonly IKullaniciBS _kullaniciBS;
        private readonly ISessionManager _session;
        IMemoryCache _cache;
        IMenuBS _menuBS;

        public YoneticiController(IKullaniciBS kullaniciBS, ISessionManager session, IMenuBS menuBS, IMemoryCache cache)
        {
            _kullaniciBS = kullaniciBS;
            _session = session;
            _menuBS = menuBS;
            _cache = cache;
        }

        // Session Kullanıcı Bazlı Sunucuda bilgi saklar
        // Her kullanıcı için ortak bir alandır. 
        // Sessiondan daha hızlı çalışır.


        // Daha az değişime uğrayan veriler için performans amaçlı kullanılır.
        // In Memory Cache (MemCache)

        // Distributed Cache (Redis)
        // json formatında cahce bellek te verileri saklamak için kullanılır

        // Response Cache
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {



            string? Id = HttpContext.Request.Cookies["AktifYoneticiCookie"];
            if (!string.IsNullOrEmpty(Id))
            {

                int kid = Convert.ToInt32(Id);
                Kullanici k = _kullaniciBS.Get(x => x.Id == kid);
                if (k != null)
                {
                    _session.AktifYonetici = k;
                    return RedirectToAction("Index", "Panel");


                }



            }



            //  _cache.Set<string>("isim", "Sinan");

            // Cookie ye kayıt için Response işlemi kullanılır.
            // Cookie den kayıt okumak için Request kullanılır.






            LoginVm vm = new LoginVm();

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Login(LoginVm kullanici)
        {

            kullanici.Email = "vektorelyazilimsinanhoca@gmail.com";
            kullanici.Sifre = "Sinan2590@";

            //if (!ModelState.IsValid)
            //{
            //    return View(kullanici);
            //}

            //string guvenlikkodu = _session.GuvenlikKodu;
            //if (kullanici.GuvenlikKodu != guvenlikkodu)
            //{
            //    TempData["Mesaj"] = "GüvenlikKodu Hatalı. ";
            //    return View();
            //}

            string CryptoPassword = CryptoManager.SHA256Encrypt(kullanici.Sifre);
            // 12345  
            //string CryptoPassword = CryptoManager.AESEncrypt(kullanici.Sifre, "SparkMarketKey");


            Kullanici kullanici1 = _kullaniciBS.Get(x => x.Email == kullanici.Email && x.Sifre == CryptoPassword, false, "KullaniciRols", "KullaniciRols.Rol");

            // Session da bir kullanıcıyı saklarken, artık rolleri ile beraber saklıyorum.


            //  // AES ile şifreli şifre
            //string kullanıcınsifresi =   CryptoManager.AESDecrypt(kullanici1.Sifre, "SparkMarketKey");

            if (kullanici1 != null)
            {

                _session.AktifYonetici = kullanici1;

                // _cache.Set<Kullanici>("Aktif", _session.AktifYonetici);


                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddYears(1); //Ben yok etmezsem sen 1 yıl dursun sonra kendiliğinden silinsin
                HttpContext.Response.Cookies.Append("AktifYoneticiCookie", kullanici1.Id.ToString(), options);

                return RedirectToAction("Index", "Panel");
            }
            else
            {
                TempData["Mesaj"] = "Giriş Hatalı.";
            }

            return View();
        }



        public IActionResult GetCaptcha()
        {
            CaptchaGenerator captcha = new CaptchaGenerator(6, "Verdana", 20);
            Bitmap b = captcha.GuvenlikResmiUret();
            _session.GuvenlikKodu = captcha.olusturanString;

            byte[] imagebyte = Converters.ImageToByteArray(b);


            return File(imagebyte, "image/jpg");
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }
        public IActionResult Logout()
        {
            _session.AktifYonetici = null;

            HttpContext.Response.Cookies.Delete("AktifYoneticiCookie");





            return RedirectToAction("Login");
        }
        public IActionResult YetkinizYok()
        {
            return View();
        }
    }
}
